using InvestmentDataContext.Classifications;
using InvestmentDataContext.Entities.Owned;

namespace InvestmentDataContext.Entities
{
    /// <summary>
    ///     Represents value (worth) of specific asset at particular date.
    /// </summary>
    public class AssetValue : InvestmentDataRecord
    {
        /// <summary>
        ///     Report date.
        /// </summary>
        public override DateTime Date { get; set; }
        /// <summary>
        ///     Information regarding the fund in which portfolio the asset is located.
        /// </summary>
        public override FundInfo Fund { get; set; } = null!;
        /// <summary>
        ///     Information regarding the investing portfolio an asset belongs to. 
        /// </summary>
        public override PortfolioInfo Portfolio { get; set; } = null!;
        /// <summary>
        ///     Information regarding the issuer of corresponding asset.
        /// </summary>
        public override IssuerInfo Issuer { get; set; } = null!;
        /// <summary>
        ///     Asset ISIN code.
        /// </summary>
        public override string Isin { get; set; } = null!;
        /// <summary>
        ///     Information about security that represents specific asset.
        /// </summary>
        public override SecurityInfo Security { get; set; } = null!;
        /// <summary>
        ///     Quantity of particular asset at report date. 
        /// </summary>
        public override double? Amount { get; set; }
        /// <summary>
        ///     Total net value of particular asset at report date. 
        /// </summary>
        public override double? NetValue { get; set; }
        /// <summary>
        ///     Total accrued interest of particular asset at report date. 
        /// </summary>
        public override double? AccruedInterest { get; set; }
        /// <summary>
        ///     Total full value of particular asset at report date.
        /// </summary>
        public override double FullValue { get; set; }
        /// <summary>
        ///     Interest rate information related to interest-based assets such as Deposits or REPO.
        /// </summary>
        public InterestRateInfo Interest { get; set; } = null!;
        /// <summary>
        ///     Information regarding creditworthiness of corresponding asset.
        /// </summary>
        public CreditRatingInfo CreditRating { get; set; } = null!;
        /// <summary>
        ///     Method of accounting for particular asset.
        /// </summary>
        public AccountingMethod AccountingMethod { get; set; }
        /// <summary>
        ///     Report-specific pricing information for this asset.
        /// </summary>
        public PricingInfo Pricing { get; set; } = null!;
        /// <summary>
        ///     Load time (instance creation time in fact).
        /// </summary>
        public DateTime LoadTime { get; set; } = DateTime.Now;
        /// <summary>
        ///     Report source file name.
        /// </summary>
        public string ReportName { get; set; } = null!;
        /// <summary>
        ///     Prices used in report source file.
        /// </summary>
        public ReportPricingType ReportPricing { get; set; }
        /// <summary>
        ///     Corresponding market information regarding the security that represents specific asset in the flow.   
        /// </summary>
        /// <remarks>
        ///     Reflects one-to-many relationship (navigation property).
        /// </remarks>
        public override ReferenceMarketInfo MarketInfo { get; set; } = null!;
        /// <summary>
        ///     Report source file information.
        /// </summary>
        /// <remarks>
        ///     Reflects one-to-many relationship (navigation property).
        /// </remarks>
        public override ReportSourceFile Report { get; set; } = null!;
    }
}
