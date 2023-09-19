using InvestmentData.Classifications;
using Newtonsoft.Json;

namespace InvestmentData
{
    /// <summary>
    ///     Represent set of mappings used withen Invetment Data context.
    /// </summary>
    public sealed class Mapper
    {
        /// <summary>
        ///     Creates mapper with predefined mappings. 
        /// </summary>
        public Mapper()
        {
            // adding pension property mapping
            PensionPropertyMapping.Add("пн", PensionPropertyType.PN);
            PensionPropertyMapping.Add("вр", PensionPropertyType.PN);
            PensionPropertyMapping.Add("св", PensionPropertyType.PN);
            PensionPropertyMapping.Add("ропс", PensionPropertyType.PN);
            PensionPropertyMapping.Add("пн граждан, переданные через нпф", PensionPropertyType.PN);
            PensionPropertyMapping.Add("пр", PensionPropertyType.PR);
            PensionPropertyMapping.Add("ср", PensionPropertyType.PR);
            PensionPropertyMapping.Add("сс", PensionPropertyType.SS);

            // adding asset type mapping
            AssetTypeMapping.Add("деньги", AssetType.Cash);
            AssetTypeMapping.Add("денежные средства", AssetType.Cash);
            AssetTypeMapping.Add("акция", AssetType.Equity);
            AssetTypeMapping.Add("выпуск акции", AssetType.Equity);
            AssetTypeMapping.Add("депозитарная расписка", AssetType.Equity);
            AssetTypeMapping.Add("ипотечный сертификат", AssetType.OtherAssets);
            AssetTypeMapping.Add("дебиторская задолженность по репо", AssetType.Repo);
            AssetTypeMapping.Add("дебиторская задолженность по сделкам репо", AssetType.Repo);
            AssetTypeMapping.Add("денежные средства на брокерских счетах", AssetType.Cash);
            AssetTypeMapping.Add("денежные средства на расчетных счетах", AssetType.Cash);
            AssetTypeMapping.Add("переоценка по сделкам т+", AssetType.Cash);
            AssetTypeMapping.Add("прочая дебиторская задолженность", AssetType.Receivables);
            AssetTypeMapping.Add("прочая кредиторская задолженность", AssetType.Payables);
            AssetTypeMapping.Add("облигации корпоративные", AssetType.CorporateBond);
            AssetTypeMapping.Add("облигации корпоративные рф", AssetType.CorporateBond);
            AssetTypeMapping.Add("облигации государственных корпораций", AssetType.CorporateBond);
            AssetTypeMapping.Add("облигации прочих резидентов", AssetType.CorporateBond);
            AssetTypeMapping.Add("облигации кредитных организаций - резидентов", AssetType.CorporateBond);
            AssetTypeMapping.Add("облигации нфо рф", AssetType.CorporateBond);
            AssetTypeMapping.Add("облигации российских хоз. обществ", AssetType.CorporateBond);
            AssetTypeMapping.Add("облигации банковские рф", AssetType.CorporateBond);
            AssetTypeMapping.Add("облигации субъектов рф", AssetType.SubfederalBond);
            AssetTypeMapping.Add("облигации муниципальные", AssetType.SubfederalBond);
            AssetTypeMapping.Add("гос.облигации субъектов рф", AssetType.SubfederalBond);
            AssetTypeMapping.Add("облигации субфедеральные", AssetType.SubfederalBond);
            AssetTypeMapping.Add("кредиторская задолженность", AssetType.Payables);
            AssetTypeMapping.Add("дебиторская задолженность", AssetType.Receivables);
            AssetTypeMapping.Add("дебиторская задолженность по ценным бумагам", AssetType.Receivables);
            AssetTypeMapping.Add("облигации государственные рф", AssetType.GovernmentBond);
            AssetTypeMapping.Add("облигации органов исполнительной власти рф и банка россии", AssetType.GovernmentBond);
            AssetTypeMapping.Add("государственные цб", AssetType.GovernmentBond);
            AssetTypeMapping.Add("гцб рф", AssetType.GovernmentBond);
            AssetTypeMapping.Add("гос. ц/б  рф", AssetType.GovernmentBond);
            AssetTypeMapping.Add("акции", AssetType.Equity);
            AssetTypeMapping.Add("паи паевых инвестиционных фондов", AssetType.MutualFund);
            AssetTypeMapping.Add("прочие активы", AssetType.OtherAssets);
            AssetTypeMapping.Add("фьючерсные контракты", AssetType.OtherAssets);
            AssetTypeMapping.Add("депозиты", AssetType.Deposit);
            AssetTypeMapping.Add("иностранная валюта", AssetType.Currency);

            // adding asset class mapping
            AssetClassMapping.Add("деньги", AssetClass.Cash);
            AssetClassMapping.Add("денежные средства", AssetClass.Cash);
            AssetClassMapping.Add("акция", AssetClass.Equities);
            AssetClassMapping.Add("выпуск акции", AssetClass.Equities);
            AssetClassMapping.Add("депозитарная расписка", AssetClass.Equities);
            AssetClassMapping.Add("ипотечный сертификат", AssetClass.OtherAssets);
            AssetClassMapping.Add("дебиторская задолженность по репо", AssetClass.Repo);
            AssetClassMapping.Add("дебиторская задолженность по сделкам репо", AssetClass.Repo);
            AssetClassMapping.Add("денежные средства на брокерских счетах", AssetClass.Cash);
            AssetClassMapping.Add("денежные средства на расчетных счетах", AssetClass.Cash);
            AssetClassMapping.Add("переоценка по сделкам т+", AssetClass.Cash);
            AssetClassMapping.Add("прочая дебиторская задолженность", AssetClass.Cash);
            AssetClassMapping.Add("прочая кредиторская задолженность", AssetClass.Cash);
            AssetClassMapping.Add("облигации корпоративные", AssetClass.Bonds);
            AssetClassMapping.Add("облигации корпоративные рф", AssetClass.Bonds);
            AssetClassMapping.Add("облигации государственных корпораций", AssetClass.Bonds);
            AssetClassMapping.Add("облигации органов исполнительной власти рф и банка россии", AssetClass.Bonds);
            AssetClassMapping.Add("облигации нфо рф", AssetClass.Bonds);
            AssetClassMapping.Add("облигации российских хоз. обществ", AssetClass.Bonds);
            AssetClassMapping.Add("облигации кредитных организаций - резидентов", AssetClass.Bonds);
            AssetClassMapping.Add("облигации банковские рф", AssetClass.Bonds);
            AssetClassMapping.Add("облигации субъектов рф", AssetClass.Bonds);
            AssetClassMapping.Add("облигации муниципальные", AssetClass.Bonds);
            AssetClassMapping.Add("гос.облигации субъектов рф", AssetClass.Bonds);
            AssetClassMapping.Add("облигации прочих резидентов", AssetClass.Bonds);
            AssetClassMapping.Add("облигации субфедеральные", AssetClass.Bonds);
            AssetClassMapping.Add("кредиторская задолженность", AssetClass.Cash);
            AssetClassMapping.Add("дебиторская задолженность", AssetClass.Cash);
            AssetClassMapping.Add("дебиторская задолженность по ценным бумагам", AssetClass.Cash);
            AssetClassMapping.Add("облигации государственные рф", AssetClass.Bonds);
            AssetClassMapping.Add("государственные цб", AssetClass.Bonds);
            AssetClassMapping.Add("гцб рф", AssetClass.Bonds);
            AssetClassMapping.Add("гос. ц/б  рф", AssetClass.Bonds);
            AssetClassMapping.Add("акции", AssetClass.Equities);
            AssetClassMapping.Add("паи паевых инвестиционных фондов", AssetClass.MutualFunds);
            AssetClassMapping.Add("прочие активы", AssetClass.OtherAssets);
            AssetClassMapping.Add("фьючерсные контракты", AssetClass.OtherAssets);
            AssetClassMapping.Add("депозиты", AssetClass.Deposits);
            AssetClassMapping.Add("иностранная валюта", AssetClass.Currency);

            // adding flow transition mapping
            FlowTransitionMapping.Add("ввод денежных средств в ду", TransType.CashInflow);
            FlowTransitionMapping.Add("вывод денежных средств из ду", TransType.CashOutflow);
            FlowTransitionMapping.Add("вывод дс", TransType.CashOutflow);
            FlowTransitionMapping.Add("пенсии, переводы - поступление", TransType.CashInflow);
            FlowTransitionMapping.Add("пенсии, переводы - оплата", TransType.CashOutflow);
            FlowTransitionMapping.Add("передача ценных бумаг в ду", TransType.SecuritiesArrival);
            FlowTransitionMapping.Add("передача ценных бумаг из ду", TransType.SecuritiesWithdrawal);
            FlowTransitionMapping.Add("покупка ценных бумаг", TransType.SecuritiesPurchase);
            FlowTransitionMapping.Add("продажа ценных бумаг", TransType.SecuritiesSale);
            FlowTransitionMapping.Add("купля", TransType.SecuritiesPurchase);
            FlowTransitionMapping.Add("продажа", TransType.SecuritiesSale);
            FlowTransitionMapping.Add("первая часть репо (епс)-покупка", TransType.RepoPurchase);
            FlowTransitionMapping.Add("вторая часть репо (епс)-продажа", TransType.RepoSale);
            FlowTransitionMapping.Add("купля 1часть репо", TransType.RepoPurchase);
            FlowTransitionMapping.Add("продажа 2часть репо", TransType.RepoSale);
            FlowTransitionMapping.Add("открытие мно", TransType.MPBOpen);
            FlowTransitionMapping.Add("закрытие мно", TransType.MPBClosure);
            FlowTransitionMapping.Add("выплата процентов по мно", TransType.InterestPayment);
            FlowTransitionMapping.Add("выплата процентов по депозиту/мно", TransType.InterestPayment);
            FlowTransitionMapping.Add("размещение депозита", TransType.DepositOpen);
            FlowTransitionMapping.Add("выплата основного тела долга по депозиту", TransType.DepositClosure);
            FlowTransitionMapping.Add("поступление дивидендов", TransType.Dividends);
            FlowTransitionMapping.Add("выплата купонного дохода", TransType.CouponPayment);
            FlowTransitionMapping.Add("погашение нкд", TransType.CouponPayment);
            FlowTransitionMapping.Add("выплата номинала/части номинала", TransType.NominalPayment);
            FlowTransitionMapping.Add("погашение / частичное погашение", TransType.NominalPayment);
            FlowTransitionMapping.Add("погашение облигации", TransType.NominalPayment);
            FlowTransitionMapping.Add("покупка валюты", TransType.CurrencyPurchase);
            FlowTransitionMapping.Add("продажа валюты", TransType.CurrencySale);
            FlowTransitionMapping.Add("прочие поступления денежных средств", TransType.OtherCashInflow);
            FlowTransitionMapping.Add("прочие списания денежных средств", TransType.OtherCashOutflow);
            FlowTransitionMapping.Add("услуги спецдепозитария", TransType.SDServices);
            FlowTransitionMapping.Add("оплата вознаграждения ук", TransType.AMServices);
            FlowTransitionMapping.Add("депозитарные расходы", TransType.OtherCosts);
            FlowTransitionMapping.Add("перевод между счетами - списание средств", TransType.InternalCashFlow);
            FlowTransitionMapping.Add("перевод между счетами - поступление средств", TransType.InternalCashFlow);

            // adding accounting method mapping
            AccountingMethodMapping.Add(string.Empty, AccountingMethod.None);
            AccountingMethodMapping.Add("не применимо", AccountingMethod.None);
            AccountingMethodMapping.Add("по справедливой", AccountingMethod.Fair);
            AccountingMethodMapping.Add("по справедливой через пу", AccountingMethod.Fair);
            AccountingMethodMapping.Add("dfpl - активы/обязательства, переоцениваемые по справедливой стоимости через прибыль или убыток", AccountingMethod.Fair);
            AccountingMethodMapping.Add("по амортизированной", AccountingMethod.Amortized);
            AccountingMethodMapping.Add("htm - инвестиции до погашения", AccountingMethod.HoldToMaturity);
            AccountingMethodMapping.Add("до погашения", AccountingMethod.HoldToMaturity);
        }

        /// <summary>
        ///     String-enum mapping for pension property type.
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, PensionPropertyType> PensionPropertyMapping { get; set; } = new();
        /// <summary>
        ///     String-enum mapping for flow transition type.
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, TransType> FlowTransitionMapping { get; set; } = new();
        /// <summary>
        ///     String-enum mapping for asset type.
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, AssetType> AssetTypeMapping { get; set; } = new();
        /// <summary>
        ///     String-enum mapping for asset class.
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, AssetClass> AssetClassMapping { get; set; } = new();
        /// <summary>
        ///     String-enum mapping for security accounting method.
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, AccountingMethod> AccountingMethodMapping { get; set; } = new();
        /// <summary>
        ///     Contract-ID -> strategy-name mapping (JSON serialized).
        /// </summary>
        public Dictionary<string, string> ContractStrategyMapping { get; set; } = new();
        /// <summary>
        ///     List of ISIN's that are considered to be risk assets.
        /// </summary>
        public Dictionary<string, RiskType> RiskIsins { get; set; } = new();

    }
}
