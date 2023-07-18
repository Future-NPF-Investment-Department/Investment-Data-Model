#pragma warning disable IDE0090

using CsvHelper;
using InvestmentDataContext.Classifications;
using InvestmentDataContext.Entities;
using InvestmentDataContext.Entities.Owned;
using InvestmentDataContext.CsvInterop;
using RuDataAPI;
using RuDataAPI.Extensions;

using InvestmentDataContext.src.CsvInterop;
using CsvHelper.Configuration;

namespace InvestmentDataContext
{
    /// <summary>
    /// 
    /// </summary>
    public static class InvestmentDataManager
    {
        private static string? _connstr;
        private static EfirCredentials? _credentials;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public static void UseConnectionString(string connectionString) 
            => _connstr = connectionString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="credentials"></param>
        public static void UseEfirCredentials(EfirCredentials? credentials)
            => _credentials = credentials;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportFile"></param>
        /// <param name="loadingContext"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task LoadReport(FileInfo reportFile, ReportLoadingContext loadingContext)
        {
            const SqlTargetTable PORTF = SqlTargetTable.Portfolio;
            const SqlTargetTable FLOWS = SqlTargetTable.Flows;

            if (_connstr is null)
                throw new Exception("Connection string is not specified.");

            if (_credentials is null)
                throw new Exception("EFIR credentials are not specified.");

            using var context = new InvestmentData(_connstr);
            var loadedReports = context.Reports;
            var loadedReportNames = loadedReports.Select(rep => rep.FileName).ToHashSet();
            if (loadedReportNames.Contains(reportFile.Name)) return;                    

            var fixPeriods = context.FixationPeriods;
            var knownIsins = context.Securities.Select(sec => sec.Isin!).ToHashSet();
            var newSecurities = new List<ReferenceMarketInfo>();

            var target = loadingContext.SqlTargetTable;     // target sql table to load to
            var pricing = loadingContext.ReportPricingType; // fair or real prices in report
            var provider = loadingContext.FileProvider;     // asset management name
            var mapper = loadingContext.Mappings;           // dicts for csv report mappings
            var config = loadingContext.CsvConfiguration;   // csv read-write config
            var encoding = loadingContext.Encoding;         // encoding of csv report

            IReportSourceFileVisitor visitor = target is PORTF
                    ? new PortfolioReportCsvSchema(mapper)
                    : new FlowsReportCsvSchema(mapper);

            ReportSourceFile report = ReportSourceFile.New(reportFile, provider, pricing, target);
            Notify?.Invoke($"Processing report: {report.FileName}");
            report.AcceptConfigurer(visitor);

            using var reader = new StreamReader(reportFile.FullName, encoding); //report.FileDirectoryName
            using var csvreader = new CsvReader(reader, config);

            csvreader.Context.RegisterClassMap(report.CsvMapping);

            List<InvestmentDataRecord> records = target is PORTF
                        ? csvreader.GetRecords<AssetValue>().Cast<InvestmentDataRecord>().ToList()
                        : csvreader.GetRecords<AssetFlow>().Cast<InvestmentDataRecord>().ToList();

            // Empty portfolio absence validation
            if (target is PORTF && records.Count is 0)
                throw new Exception($"Csv report {report.FileName} contains no records.");

            report.RecordsNumber = records.Count;

            // Unique report date validation
            var uniqueDatesNumber = records.DistinctBy(rep => rep.Date.Date).Count();
            if (target is PORTF)
            {
                string errmes = $"Csv {report.Destination} report '{report.FileName}' contains data for more than one date.";
                report.ReportDate = uniqueDatesNumber is 1
                    ? records[0].Date
                    : throw new Exception(errmes);            
            }        
            else if (target is FLOWS)
            {
                report.ReportDate = uniqueDatesNumber is 1
                    ? records[0].Date
                    : null;
            }



            // report dublicate validation
            if (report.ReportDate is not null)
            {
                foreach (var rep in loadedReports)
                {
                    if (report.Equals(rep))
                    {
                        string message = $"Error for '{report.FileName}': " +
                            $"report with same parameters already exists in database:\n" +
                            $"Report provider: {rep.Provider}\n" +
                            $"Report type: {rep.Destination}\n" +
                            $"Report date: {rep.ReportDate?.ToShortDateString()}\n" +
                            $"Report pricing: {rep.PricingType}\n" +
                            $"check id {rep.Id}";
                        Warning?.Invoke(message);
                        break;
                    }
                }
            }

            
            using var efir = new EfirClient(_credentials);
            foreach (var rec in records)
            {
                // enriching assets from portfolio report with pricing information
                if (target is PORTF)
                {
                    var fundSpecificFixPeriods = fixPeriods.Where(pfi => pfi.FundName == rec.Fund.FundName);
                    ((AssetValue)rec).Pricing = PricingInfo.DefineReportPricing(report, fundSpecificFixPeriods);
                }

                // extracting data for newly found ISIN's
                if (knownIsins.Contains(rec.Isin) is false)
                {
                    if (efir.IsLoggedIn is false)
                        await efir.LoginAsync();

                    EfirSecurity sec = await efir.GetSecurityData(rec.Isin);
                    ReferenceMarketInfo info = ReferenceMarketInfo.New(sec, rec.Security.AssetClass, rec.Security.RiskType);
                    newSecurities.Add(info);
                    knownIsins.Add(rec.Isin);
                }
            }
            
            context.Reports.Add(report);

            if (newSecurities.Count > 0)
                context.Securities.AddRange(newSecurities);

            if (target is PORTF)
                context.Assets.AddRange(records.Cast<AssetValue>());

            if (target is FLOWS)
                context.Flows.AddRange(records.Cast<AssetFlow>());

            context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportId"></param>
        /// <exception cref="Exception"></exception>
        public static void RemoveReportFromContext(int reportId)
        {
            if (_connstr is null)
                throw new Exception("Connection string is not specified");

            using var context = new InvestmentData(_connstr);
            var report = context.Reports.Where(rep => rep.Id == reportId).FirstOrDefault(); 
            
            if (report is not null)
            {
                context.Reports.Remove(report);
                context.SaveChanges();
                string message = $"Report '{report.FileName}' and its records ({report.RecordsNumber}) have been deleted from database.";
                Notify?.Invoke(message);
            }
            else
            {
                Warning?.Invoke($"No report found with ID {reportId}.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static AssetsQueryBuilder NewAssetsQuery(InvestmentData context)        
            => new AssetsQueryBuilder(context);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static AssetsQueryBuilder NewAssetsQuery()
        {
            if (_connstr is null)
                throw new Exception("Connection string is not specified");
            using var context = new InvestmentData(_connstr);
            return NewAssetsQuery(context);
        }
        
        /// <summary>
        ///     
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static FlowsQueryBuilder NewFlowsQuery(InvestmentData context)
            => new FlowsQueryBuilder(context);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static FlowsQueryBuilder NewFlowsQuery()
        {
            if (_connstr is null)
                throw new Exception("Connection string is not specified");
            using var context = new InvestmentData(_connstr);
            return NewFlowsQuery(context);
        }


        /// <summary>
        /// 
        /// </summary>
        public static event Action<string>? Notify;
        /// <summary>
        /// 
        /// </summary>
        public static event Action<string>? Warning;
    }
}
