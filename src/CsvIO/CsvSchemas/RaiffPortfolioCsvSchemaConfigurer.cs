using InvestmentData.Context.Entities;

namespace InvestmentData.CsvIO.CsvSchemas
{
    /// <summary>
    ///     Configurer for Portfolio csv schema (Raiffeisen format)
    /// </summary>
    public class RaiffPortfolioCsvSchemaConfigurer : ICsvSchemaConfigurer<AssetValue>
    {
        public void ConfigureCsvChema(CsvSchema<AssetValue> csvSchema)
        {
            var mapper = csvSchema.Mapper;
            var report = csvSchema.Report;

            csvSchema.Map(av => av.Portfolio.PensionProperty)
                .Name("Вид имущества")
                .PremapWithDict(mapper.PensionPropertyMapping);

            csvSchema.Map(av => av.Portfolio.StrategyName)
                .Name("Номер и дата договора")
                .PremapWithDict(mapper.ContractStrategyMapping, true);

            csvSchema.Map(av => av.Security.AssetType)
                .Name("Тип актива")
                .PremapWithDict(mapper.AssetTypeMapping);

            csvSchema.Map(av => av.Security.AssetClass)
                .Name("Тип актива")
                .PremapWithDict(mapper.AssetClassMapping);

            csvSchema.Map(av => av.AccountingMethod)
                .Name("Метод учета")
                .PremapWithDict(mapper.AccountingMethodMapping);

            csvSchema.Map(av => av.Security.RiskType)
                .Name("ISIN")
                .CheckRiskIsin(mapper.RiskIsins);

            csvSchema.Map(av => av.Fund.FundName)
                .Name("Наименование фонда")
                .RemoveQuotes();

            csvSchema.Map(av => av.Date)
                .UseCulture("ru-RU")
                .Name("Дата");

            csvSchema.Map(av => av.Portfolio.Contract)
                .Name("Номер и дата договора");

            csvSchema.Map(av => av.Issuer.Name)
                .Name("Эмитент / Контрагент")
                .RemoveQuotes();

            csvSchema.Map(av => av.Issuer.Inn)
                .Name("ИНН Контрагента / Эмитента");

            csvSchema.Map(av => av.Security.RegNumber)
                .Name("Рег. номер");

            csvSchema.Map(av => av.Isin)
                .Name("ISIN");

            csvSchema.Map(av => av.Security.ShortName)
                .Name("Краткое наименование инструмента")
                .RemoveQuotes();

            csvSchema.Map(av => av.Security.FullName)
                .Name("Полное наименование инструмента")
                .RemoveQuotes();

            csvSchema.Map(av => av.Security.Notional)
                .Name("Номинал")
                .UniversalSeparatorDouble()
                ;

            csvSchema.Map(av => av.Security.Currency)
                .Name("Валюта");

            csvSchema.Map(av => av.Amount)
                .Name("Количество (без учета РЕПО)")
                .UniversalSeparatorDouble()
                ;

            csvSchema.Map(av => av.NetValue)
                .Name("Сумма без НКД");

            csvSchema.Map(av => av.AccruedInterest)
                .Name("НКД, руб.")
                .UniversalSeparatorDouble()
                ;

            csvSchema.Map(av => av.FullValue)
                .Name("Сумма с НКД, руб.");

            csvSchema.Map(av => av.Interest.DepositExpirationDate)
                .Name("Дата погашения депозита");

            csvSchema.Map(av => av.Interest.CurrentRate)
                .Name("Текущая процентная ставка по депозиту")
                .UniversalSeparatorDouble()
                ;

            csvSchema.Map(av => av.Interest.RateType)
                .Name("Вид процентной ставки по депозиту");

            csvSchema.Map(av => av.CreditRating.InstrumentBestRating)
                .Name("Лучший рейтинг инструмента");

            csvSchema.Map(av => av.CreditRating.InstrumentRatingAgency)
                .Name("Рейтинговое агентство инструмента");

            csvSchema.Map(av => av.CreditRating.EmitentBestRating)
                .Name("Лучший рейтинг эмитента");

            csvSchema.Map(av => av.CreditRating.EmitentRatingAgency)
                .Name("Рейтинговое агентство эмитента");

            csvSchema.Map(av => av.Fund.AmName)
                .Constant(report.Provider);

            csvSchema.Map(av => av.ReportPricing)
                .Constant(report.PricingType);

            csvSchema.Map(av => av.ReportName)
                .Constant(report.FileName);

            csvSchema.Map(av => av.MarketInfo).Ignore();
            csvSchema.Map(av => av.Report).Ignore();
            csvSchema.Map(av => av.LoadTime).Ignore();
        }
    }
}
