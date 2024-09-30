
namespace InvestmentDataModel
{
    /// <summary>
    ///     Represents an abstrct record of investment data.
    /// </summary>
    public abstract class InvestDataEntryBase
    {
        /// <summary>
        ///     Report date.
        /// </summary>
        public abstract DateTime Date { get; set; }



        /// <summary>
        /// Name of fund.
        /// </summary>
        public abstract string FundName { get; set; }
        /// <summary>
        /// Asset management company name.
        /// </summary>
        public abstract string AmName { get; set; }
        /// <summary>
        ///     Information regarding the fund.
        /// </summary>
        //public abstract FundInfoEntry Fund { get; set; }



        /// <summary>
        ///     Type of pension property.
        /// </summary>
        public abstract PensionPropertyType PensionProperty { get; set; }
        /// <summary>
        ///     Strategy name.
        /// </summary>
        public abstract string StrategyName { get; set; }
        /// <summary>
        ///     Contract ID.
        /// </summary>
        public abstract string Contract { get; set; }
        /// <summary>
        ///     Current account ID.
        /// </summary>
        public abstract string? RsNumber { get; set; }
        ///// <summary>
        /////      Investing portfolio Information. 
        ///// </summary>
        //public abstract PortfolioEntry Portfolio { get; set; }




        /// <summary>
        ///     Emitent name.
        /// </summary>
        public abstract string? Name { get; set; }
        /// <summary>
        ///     Emitent ID.
        /// </summary>
        public abstract string? Inn { get; set; }
        ///// <summary>
        /////      Iissuer information.
        ///// </summary>
        //public abstract IssuerEntry Issuer { get; set; }



        /// <summary>
        ///     ISIN code.
        /// </summary>
        public abstract string Isin { get; set; }





        /// <summary>
        ///     Asset class (e.g. equities, bonds, cash etc.)
        /// </summary>
        public abstract AssetClass AssetClass { get; set; }
        /// <summary>
        ///     Asset type (e.g. gov bonds, corp bonds, etc.).
        /// </summary>
        public abstract AssetType AssetType { get; set; }
        /// <summary>
        ///     Asset registration number (if any).
        /// </summary>
        public abstract string RegNumber { get; set; }
        /// <summary>
        ///     Security short name.
        /// </summary>
        public abstract string? ShortName { get; set; }
        /// <summary>
        ///     Security full name
        /// </summary>
        public abstract string? FullName { get; set; }
        /// <summary>
        ///     Risk group to which security belongs to.
        /// </summary>
        public abstract RiskType RiskType { get; set; }
        /// <summary>
        ///     Security notional.
        /// </summary>
        public abstract double? Notional { get; set; }
        /// <summary>
        ///     Currency of security's notional.
        /// </summary>
        public abstract string? Currency { get; set; }
        ///// <summary>
        /////      Security Information.
        ///// </summary>
        //public abstract SecurityInfoEntry Security { get; set; }






        /// <summary>
        ///     Corresponding amount. 
        /// </summary>
        public abstract double? Amount { get; set; }
        /// <summary>
        ///     Corresponding net value. 
        /// </summary>
        public abstract double? NetValue { get; set; }
        /// <summary>
        ///     Corresponding accrued interest. 
        /// </summary>
        public abstract double? AccruedInterest { get; set; }
        /// <summary>
        ///     Corresponding full value.
        /// </summary>
        public abstract double FullValue { get; set; }
        /// <summary>
        ///     Corresponding market information.
        /// </summary>
        public abstract Security MarketInfo { get; set; }
        /// <summary>
        ///     Information about source file.
        /// </summary>
        public abstract SourceFile Report { get; set; }
    }
}
