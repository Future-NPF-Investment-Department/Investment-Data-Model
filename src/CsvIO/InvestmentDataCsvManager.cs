using CsvHelper;
using CsvHelper.Configuration;
using InvestmentDataContext.Classifications;
using InvestmentDataContext.Entities;
using InvestmentDataContext.Entities.Owned;
using RuDataAPI;
using RuDataAPI.Extensions;
using System.Text;

namespace InvestmentDataContext.CsvIO
{
    public class InvestmentDataCsvManager
    {
        private static readonly InvestmentDataCsvManager _singletonInstance = new();

        private string _connstr;
        private EfirCredentials? _creds;
        private Mapper? _mapper;
        private PathsInfo? _pathsInfo;
        private Encoding _encoding = Encoding.UTF8;

        static InvestmentDataCsvManager() { }
        private InvestmentDataCsvManager()
            => _connstr = InvestmentData.DFLTCONNSTR;

        public static InvestmentDataCsvManager Instance => _singletonInstance;

        /// <summary>
        ///     Tells IO Manager what connection string to use while performing IO operations within context.
        /// </summary>
        /// <param name="connectionString"> <see cref="InvestmentData"/> context connection string. </param>
        public void UseConnectionString(string connectionString)
            => _connstr = connectionString;

        /// <summary>
        ///     Tells IO Manager what credentials to use when connecting to <see cref="EfirClient"/>.
        /// </summary>
        /// <param name="credentials">credentials for <see cref="EfirClient"/>.</param>
        public void UseEfirCredentials(EfirCredentials credentials)
            => _creds = credentials;

        /// <summary>
        ///     Tells IO Manager what mappings to use while performing IO operations within context.
        /// </summary>
        /// <param name="mapper"></param>
        public void UseMapper(Mapper mapper)
            => _mapper = mapper;

        /// <summary>
        ///     Tells IO Manager to use relevant paths information for performing IO operations.
        /// </summary>
        /// <param name="pathsInfo"></param>
        public void UsePathsInfo(PathsInfo pathsInfo)
            => _pathsInfo = pathsInfo;

        /// <summary>
        ///     Tells IO Manager what encoding to use while performing read-write operations.
        /// </summary>
        public void UseEncoding(Encoding encoding)
            => _encoding = encoding;

        /// <summary>
        ///     Registers an encodeing provider.
        /// </summary>
        /// <param name="codepage"></param>
        public void RegisterEncoding(int codepage)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var encoding = Encoding.GetEncoding(codepage);
            UseEncoding(encoding);
        }

        /// <summary>
        ///     Writes data to csv file.
        /// </summary>
        /// <typeparam name="T"><see cref="InvestmentDataRecord"/>.</typeparam>
        /// <param name="data">data to write to csv.</param>
        /// <param name="csvPath">csv file path.</param>
        public void WriteDataToCsv<T> (IEnumerable<T> data, string csvPath, CsvConfiguration config) where T : InvestmentDataRecord
        {

        }

        public async Task LoadDataFromCsv(FileInfo file, CsvConfiguration config)
        {
            const SqlTargetTable PORTF = SqlTargetTable.Portfolio;
            const SqlTargetTable FLOWS = SqlTargetTable.Flows;

            if (_connstr is null)
                throw new Exception("Connection string is not specified.");

            if (_creds is null)
                throw new Exception("EFIR credentials are not specified.");

            if (_pathsInfo is null)
                throw new Exception("Paths info is not specified. Check your json file to read it.");

            if (_mapper is null)
                throw new Exception("Mappings are not specified. Check your json file to read it.");

            var path = file.DirectoryName is not null 
                ? file.DirectoryName 
                : throw new Exception("Csv file path cannot be null.");

            using var context = new InvestmentData(_connstr);
            var loadedReports = context.Reports;
            var loadedReportNames = loadedReports.Select(rep => rep.FileName).ToHashSet();
            if (loadedReportNames.Contains(file.Name)) return;

            var fixPeriods = context.FixationPeriods;
            var knownIsins = context.Securities.Select(sec => sec.Isin!).ToHashSet();
            var newSecurities = new List<ReferenceMarketInfo>();

            var target = _pathsInfo.SqlTargetFlags[path];       // target sql table to load to
            var pricing = _pathsInfo.PricingFlags[path];        // fair or real prices in report
            var provider = _pathsInfo.ProviderFlags[path];      // asset management name

            Console.WriteLine($"Processing report {file.Name}"); // <-----------------------------------------------------------!!!
            var report = ReportSourceFile.New(file, provider, pricing, target);
            var csvSchemaFactory = new CsvSchemaFactory(report, _mapper);
            var schema = csvSchemaFactory.Create();

            using var reader = new StreamReader(file.FullName, _encoding);
            using var csvreader = new CsvReader(reader, config);
            csvreader.Context.RegisterClassMap(schema);

            List<InvestmentDataRecord> records = target is PORTF
                        ? csvreader.GetRecords<AssetValue>().Cast<InvestmentDataRecord>().ToList()
                        : csvreader.GetRecords<AssetFlow>().Cast<InvestmentDataRecord>().ToList();

            // Empty portfolio check
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
                        Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(message); Console.ResetColor(); // <--------------------------!!
                        //Warning?.Invoke(message);
                        break;
                    }
                }
            }


            using var efir = new EfirClient(_creds);
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


    }
}
