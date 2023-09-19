using InvestmentData.Context.Entities;

namespace InvestmentData.CsvIO.CsvSchemas
{
    /// <summary>
    ///     Configurer for Flows csv schema (REGION TRUST format)
    /// </summary>
    public class RegionFlowsCsvSchemaConfigurer : ICsvSchemaConfigurer<AssetFlow>
    {
        public void ConfigureCsvChema(CsvSchema<AssetFlow> csvSchema)
        {
            var mapper = csvSchema.Mapper;
            var report = csvSchema.Report;

            csvSchema.Map(af => af.Id)
                .Name("Номер сделки");

            csvSchema.Map(af => af.Portfolio.PensionProperty)
                .Name("Вид имущества")
                .PremapWithDict(mapper.PensionPropertyMapping);

            csvSchema.Map(af => af.Portfolio.Contract)
                .Name("Номер и дата договора");

            csvSchema.Map(af => af.Portfolio.StrategyName)
                .Name("Номер и дата договора")
                .PremapWithDict(mapper.ContractStrategyMapping, true);

            csvSchema.Map(af => af.Fund.FundName)
                .Name("Наименование фонда")
                .RemoveQuotes();

            csvSchema.Map(af => af.Security.ShortName)
                .Name("Краткое наименование инструмента")
                .RemoveQuotes();

            csvSchema.Map(af => af.Security.AssetType)
                .Name("Тип актива")
                .PremapWithDict(mapper.AssetTypeMapping);

            csvSchema.Map(af => af.Security.AssetClass)
                .Name("Тип актива")
                .PremapWithDict(mapper.AssetClassMapping);

            csvSchema.Map(af => af.Portfolio.RsNumber)
                .Name("Номер расчетного счета, по которому произошло движение ДС");

            csvSchema.Map(af => af.Security.RegNumber)
                .Name("Рег. номер");

            csvSchema.Map(af => af.Isin)
                .Name("ISIN");

            csvSchema.Map(af => af.OperationDate)
                .UseCulture("ru-RU")
                .Name("Дата операции/дата заключения сделки");

            csvSchema.Map(af => af.Date)
                .UseCulture("ru-RU")
                .Name("Дата оплаты");

            csvSchema.Map(af => af.TransType)
                .Name("Тип транзакции")
                .PremapWithDict(mapper.FlowTransitionMapping);

            csvSchema.Map(af => af.NetValue)
                .Name("Сумма без НКД");

            csvSchema.Map(af => af.AccruedInterest)
                .Name("НКД, руб.");

            csvSchema.Map(af => af.FullValue)
                .Name("Сумма с НКД, руб.");

            csvSchema.Map(af => af.Amount)
                .Name("Количество");

            csvSchema.Map(af => af.Comissions.Comission)
                .Name("Комиссия биржи");

            csvSchema.Map(af => af.Comissions.BrokerComission)
                .Name("Комиссия брокера");

            csvSchema.Map(af => af.Comment)
                .Name("Доп. информация");

            csvSchema.Map(af => af.Security.RiskType)
                .Name("ISIN")
                .CheckRiskIsin(mapper.RiskIsins);

            csvSchema.Map(af => af.Fund.AmName)
                .Constant(report.Provider);

            csvSchema.Map(af => af.ReportName)
                .Constant(report.FileName);

            csvSchema.Map(af => af.MarketInfo)
                .Ignore();

            csvSchema.Map(af => af.Report)
                .Ignore();

            csvSchema.Map(af => af.LoadTime)
                .Ignore();

        }
    }
}
