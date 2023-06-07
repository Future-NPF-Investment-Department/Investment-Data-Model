using CsvHelper.Configuration;
using InvestmentDataContext.Entities;
using InvestmentDataContext.Entities.Owned;
using InvestmentDataContext.Classifications;
using CsvHelper;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata.Ecma335;

namespace InvestmentDataContext.CsvInterop
{
    public sealed class PortfolioReportCsvSchema : ClassMap<AssetValue>, IReportSourceFileVisitor
    {
        private readonly Mapper _mapper;
        public PortfolioReportCsvSchema(Mapper mapper)        
            => _mapper = mapper;
        

        public void ConfigureReportCsvSchema(ReportSourceFile report)
        {
            _ = Map(av => av.Date)
                .Name("Дата");

            _ = Map(av => av.Fund.FundName)       
                .Convert(row => row.Row.GetField("Наименование фонда")!.Replace("\"", ""));

            _ = Map(av => av.Portfolio.PensionProperty)
                .Convert(args => GetPensionPropertyType(args, "Вид имущества"));

            _ = Map(av => av.Portfolio.Contract)
                .Name("Номер и дата договора", "Наименование портфеля");

            _ = Map(av => av.Portfolio.StrategyName)
                .Convert(args => GetStrategyName(args, "Номер и дата договора", "Наименование портфеля"));

            _ = Map(av => av.Security.AssetType)
                .Convert(args => GetAssetType(args, "Тип актива"));

            _ = Map(av => av.Security.AssetClass)
                .Convert(args => GetAssetClass(args, "Тип актива"));

            _ = Map(av => av.Issuer.Name)
                .Name("Эмитент / Контрагент", "Эмитент");

            _ = Map(av => av.Issuer.Inn)
                .Name("ИНН Контрагента / Эмитента", "ИНН");

            _ = Map(av => av.Security.RegNumber)
                .Name("Рег. номер", "Рег номер");

            _ = Map(av => av.Isin)
                .Name("ISIN");

            _ = Map(av => av.Security.ShortName)
                .Name("Краткое наименование инструмента");

            _ = Map(av => av.Security.FullName)
                .Name("Полное наименование инструмента");

            _ = Map(av => av.Security.Notional)
                .Name("Номинал");

            _ = Map(av => av.Security.Currency)
                .Name("Валюта");

            _ = Map(av => av.Amount)
                .Name("Количество (без учета РЕПО)", "Количество");

            _ = Map(av => av.NetValue)
                .Name("Сумма без НКД", "Сумма");

            _ = Map(av => av.AccruedInterest)
                .Name("НКД, руб.", "НКД");

            _ = Map(av => av.FullValue)
                .Name("Сумма с НКД, руб.", "Сумма без НКД")
                .Default(.0);

            _ = Map(av => av.Interest.DepositExpirationDate)
                .Name("Дата погашения депозита");

            _ = Map(av => av.Interest.CurrentRate)
                .Name("Текущая процентная ставка по депозиту", "% ставка");

            _ = Map(av => av.Interest.RateType)
                .Name("Вид процентной ставки по депозиту");

            _ = Map(av => av.CreditRating.InstrumentBestRating)
                .Name("Лучший рейтинг инструмента");

            _ = Map(av => av.CreditRating.InstrumentRatingAgency)
                .Name("Рейтинговое агентство инструмента", "РАИнструмента");

            _ = Map(av => av.CreditRating.EmitentBestRating)
                .Name("Лучший рейтинг эмитента");

            _ = Map(av => av.CreditRating.EmitentRatingAgency)
                .Name("Рейтинговое агентство эмитента", "РАЭмитента");

            _ = Map(av => av.AccountingMethod)
                .Convert(args => GetAccountingMethod(args, "Метод учета"));

            _ = Map(av => av.Security.RiskType)
                .Convert(args => GetRiskType(args, "ISIN"));

            _ = Map(av => av.Fund.AmName)
                .Constant(report.Provider);

            _ = Map(av => av.ReportPricing)
                .Constant(report.PricingType);

            _ = Map(av => av.ReportName)
                .Constant(report.FileName);

            _ = Map(av => av.MarketInfo).Ignore();
            _ = Map(av => av.Report).Ignore();
            _ = Map(av => av.LoadTime).Ignore();

            report.CsvMapping = this;
        }

        private PensionPropertyType GetPensionPropertyType(ConvertFromStringArgs data, string csvField)
        {
            bool isSuccess = data.Row.TryGetField(csvField, out string? value);
            return isSuccess
                ? _mapper.PensionPropertyMapping[value!]
                : throw new Exception($"Cannot map \'{value!}\' from \'{csvField}\' field of csv report. Please check mappings.");
        }

        private string GetStrategyName(ConvertFromStringArgs data, params string[] csvFields)
        {
            string? value = string.Empty;
            foreach (var headerName in csvFields)
            {
                bool isSuccess = data.Row.TryGetField(headerName, out value);
                if (isSuccess)
                    return _mapper.ContractStrategyMapping[value!];
                continue; 
            }
            throw new Exception($"Cannot map \'{value!}\' from \'{csvFields}\' field of csv report. Please check mappings.");
        }

        private AssetType GetAssetType(ConvertFromStringArgs data, string csvField)
        {
            bool isSuccess = data.Row.TryGetField(csvField, out string? value);
            return isSuccess
                ? _mapper.AssetTypeMapping[value!.ToLower()]
                : throw new Exception($"Cannot map \'{value!}\' from \'{csvField}\' field of csv report. Please check mappings.");
        }

        private AssetClass GetAssetClass(ConvertFromStringArgs data, string csvField)
        {
            bool isSuccess = data.Row.TryGetField(csvField, out string? value);
            return isSuccess
                ? _mapper.AssetClassMapping[value!.ToLower()]
                : throw new Exception($"Cannot map \'{value!}\' from \'{csvField}\' field of csv report. Please check mappings.");
        }

        private AccountingMethod GetAccountingMethod(ConvertFromStringArgs data, string csvField)
        {
            bool isSuccess = data.Row.TryGetField(csvField, out string? value);
            return isSuccess
                ? _mapper.AccountingMethodMapping[value!.ToLower()]
                : throw new Exception($"Cannot map \'{value!}\' from \'{csvField}\' field of csv report. Please check mappings.");
        }

        private RiskType GetRiskType(ConvertFromStringArgs data, string csvField)
        {
            bool isSuccess = data.Row.TryGetField(csvField, out string? value);
            
            if (isSuccess)
            {
                return (_mapper.RiskIsins.Keys.Contains(value!))
                    ? RiskType.Risk
                    : RiskType.NonRisk;
            }

            throw new Exception($"Cannot map \'{value!}\' from \'{csvField}\' field of csv report. Please check mappings.");
        }
    }
}