using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using InvestmentDataContext.Classifications;
using InvestmentDataContext.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;

namespace InvestmentDataContext.CsvInterop
{
    public sealed class FlowsReportCsvSchema : ClassMap<AssetFlow>, IReportSourceFileVisitor
    {
        private readonly Mapper _mapper;

        public FlowsReportCsvSchema(Mapper mapper)        
            => _mapper = mapper;
  

        public void ConfigureReportCsvSchema(ReportSourceFile report)
        {
            _ = Map(af => af.Id)
                .Name("Номер сделки");
            
            _ = Map(af => af.Portfolio.PensionProperty)
                .Convert(args => GetPensionPropertyType(args, "Вид имущества"));
            
            _ = Map(af => af.Portfolio.Contract)
                .Name("Номер и дата договора", "Наименование портфеля");
            
            _ = Map(af => af.Portfolio.StrategyName)
                .Convert(args => GetStrategyName(args, "Номер и дата договора", "Наименование портфеля"));

            _ = Map(af => af.Fund.FundName)
                //.Name("Наименование фонда")
                //.Optional()
                .Convert(args => GetCleanFundName(args, "Наименование фонда", "АО МНПФ БОЛЬШОЙ"));                

            _ = Map(af => af.Security.ShortName)
                .Name("Краткое наименование инструмента");
            
            _ = Map(af => af.Security.AssetType)
                .Convert(args => GetAssetType(args, "Тип актива"));
            
            _ = Map(af => af.Security.AssetClass)
                .Convert(args => GetAssetClass(args, "Тип актива"));
            
            _ = Map(af => af.Portfolio.RsNumber)
                .Name("Номер расчетного счета, по которому произошло движение ДС");
            
            _ = Map(af => af.Security.RegNumber)
                .Name("Рег. номер", "Рег номер");
            
            _ = Map(af => af.Isin)
                .Name("ISIN");
            
            _ = Map(af => af.OperationDate)
                .Name("Дата операции/дата заключения сделки", "Дата операции/Дата заключения сделки");
            
            _ = Map(af => af.Date)
                .Name("Дата оплаты"); 
            
            _ = Map(af => af.TransType)
                .Convert(args => GetTransitionType(args, "Тип транзакции"));
            
            _ = Map(af => af.NetValue)
                .Name("Сумма без НКД");
            
            _ = Map(af => af.AccruedInterest)
                .Name("НКД, руб.", "НКД");
            
            _ = Map(af => af.FullValue)
                .Name("Сумма с НКД, руб.", "Сумма СНКД");
            
            _ = Map(af => af.Amount)
                .Name("Количество");
            
            _ = Map(af => af.Comissions.Comission)
                .Name("Комиссия биржи");
            
            _ = Map(af => af.Comissions.BrokerComission)
                .Name("Комиссия брокера");
            
            _ = Map(af => af.Comment)
                .Name("Доп. информация", "Доп информация");

            _ = Map(af => af.Security.RiskType)
               .Convert(args => GetRiskType(args, "ISIN"));

            _ = Map(af => af.Fund.AmName)
                .Constant(report.Provider);
            
            _ = Map(af => af.ReportName)
                .Constant(report.FileName);

            _ = Map(af => af.MarketInfo)
                .Ignore();
            
            _ = Map(af => af.Report)
                .Ignore();
            
            _ = Map(af => af.LoadTime)
                .Ignore();

            report.CsvMapping = this;
        }


        private string GetCleanFundName(ConvertFromStringArgs data, string csvField, string? defaultValue = null)
        {
            var headers = data.Row.HeaderRecord;
            if (headers is not null && headers.Contains(csvField))
            {
                bool isSuccess = data.Row.TryGetField(csvField, out string? value);
                return isSuccess && value is not null && value.Contains('"')
                    ? value.Replace("\"", string.Empty)
                    : throw new Exception($"Cannot map \'{value}\' from \'{csvField}\' field of csv report.");
            }

            if (defaultValue is not null)
                return defaultValue;

            throw new Exception($"Csv headers line does not contain '{csvField}' field and default value is not provided.");
        }

        private PensionPropertyType GetPensionPropertyType(ConvertFromStringArgs data, string csvField)
        {            
            bool isSuccess = data.Row.TryGetField(csvField, out string? value);
            return isSuccess && value is not null
                ? _mapper.PensionPropertyMapping[value]
                : throw new Exception($"Cannot map \'{value}\' from \'{csvField}\' field of csv report. Please check mappings.");
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

        private TransType GetTransitionType(ConvertFromStringArgs data, string csvField)
        {
            bool isSuccess = data.Row.TryGetField(csvField, out string? value);
            return isSuccess && value is not null
                ? _mapper.FlowTransitionMapping[value.ToLower()]
                : throw new Exception($"Cannot map \'{value}\' from \'{csvField}\' field of csv report. Please check mappings.");
        }

        private AssetType GetAssetType(ConvertFromStringArgs data, string csvField)
        {
            bool isSuccess = data.Row.TryGetField(csvField, out string? value);
            return isSuccess && value is not null
                ? _mapper.AssetTypeMapping[value.ToLower()]
                : throw new Exception($"Cannot map \'{value!}\' from \'{csvField}\' field of csv report. Please check mappings.");
        }

        private AssetClass GetAssetClass(ConvertFromStringArgs data, string csvField)
        {
            bool isSuccess = data.Row.TryGetField(csvField, out string? value);
            return isSuccess && value is not null
                ? _mapper.AssetClassMapping[value.ToLower()]
                : throw new Exception($"Cannot map \'{value}\' from \'{csvField}\' field of csv report. Please check mappings.");
        }

        private RiskType GetRiskType(ConvertFromStringArgs data, string csvField)
        {
            bool isSuccess = data.Row.TryGetField(csvField, out string? value);

            if (isSuccess && value is not null)
            {
                return _mapper.RiskIsins.ContainsKey(value) 
                    ? RiskType.Risk
                    : RiskType.NonRisk;
            }

            throw new Exception($"Cannot map \'{value}\' from \'{csvField}\' field of csv report. Please check mappings.");
        }
    }
}
