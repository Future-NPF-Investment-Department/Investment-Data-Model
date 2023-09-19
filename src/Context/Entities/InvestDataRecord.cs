using InvestmentData.Context.Entities.Owned;

namespace InvestmentData.Context.Entities
{
    /// <summary>
    ///     Represents an abstrct record of investment data.
    /// </summary>
    public abstract class InvestmentDataRecord
    {
        /// <summary>
        ///     Report date.
        /// </summary>
        public abstract DateTime Date { get; set; }
        /// <summary>
        ///     Information regarding the fund.
        /// </summary>
        public abstract FundInfo Fund { get; set; }
        /// <summary>
        ///      Investing portfolio Information. 
        /// </summary>
        public abstract PortfolioInfo Portfolio { get; set; }
        /// <summary>
        ///      Iissuer information.
        /// </summary>
        public abstract IssuerInfo Issuer { get; set; }
        /// <summary>
        ///     ISIN code.
        /// </summary>
        public abstract string Isin { get; set; }
        /// <summary>
        ///      Security Information.
        /// </summary>
        public abstract SecurityInfo Security { get; set; }
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
        public abstract ReferenceMarketInfo MarketInfo { get; set; }
        /// <summary>
        ///     Information about source file.
        /// </summary>
        public abstract ReportSourceFile Report { get; set; }
    }
}
