
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
        ///     Information regarding the fund.
        /// </summary>
        public abstract FundInfoEntry Fund { get; set; }
        /// <summary>
        ///      Investing portfolio Information. 
        /// </summary>
        public abstract PortfolioEntry Portfolio { get; set; }
        /// <summary>
        ///      Iissuer information.
        /// </summary>
        public abstract IssuerEntry Issuer { get; set; }
        /// <summary>
        ///     ISIN code.
        /// </summary>
        public abstract string Isin { get; set; }
        /// <summary>
        ///      Security Information.
        /// </summary>
        public abstract SecurityInfoEntry Security { get; set; }
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
        public abstract SecurityEntry MarketInfo { get; set; }
        /// <summary>
        ///     Information about source file.
        /// </summary>
        public abstract ReportSourceFile Report { get; set; }
    }
}
