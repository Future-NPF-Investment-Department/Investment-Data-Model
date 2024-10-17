
namespace InvestmentDataModel
{
    /// <summary>
    ///     Represents value (worth) of specific asset at particular date.
    /// </summary>
    public class NetAssetValue : InvestDataEntryBase
    {
        /// <summary>
        ///     Report date.
        /// </summary>
        public override DateTime Date { get; set; }

        /// <summary>
        /// Name of fund.
        /// </summary>
        public override string FundName { get; set; } = null!;
        
        /// <summary>
        /// Asset management company name.
        /// </summary>
        public override string AmName { get; set; } = null!;

        /// <summary>
        ///     Type of pension property.
        /// </summary>
        public override PensionPropertyType PensionProperty { get; set; }
        
        /// <summary>
        ///     Strategy name.
        /// </summary>
        public override string StrategyName { get; set; } = null!;
        
        /// <summary>
        ///     Contract ID.
        /// </summary>
        public override string Contract { get; set; } = null!;
        
        /// <summary>
        ///     Current account ID.
        /// </summary>
        public override string? RsNumber { get; set; }

        /// <summary>
        ///     Emitent name.
        /// </summary>
        public override string? EmitentName { get; set; }

        /// <summary>
        ///     Emitent ID.
        /// </summary>
        public override string? Inn { get; set; }


        /// <summary>
        ///     Asset ISIN code.
        /// </summary>
        public override string Isin { get; set; } = null!;

        /// <summary>
        ///     Asset class (e.g. equities, bonds, cash etc.)
        /// </summary>
        public override AssetClass AssetClass { get; set; }
        
        /// <summary>
        ///     Asset type (e.g. gov bonds, corp bonds, etc.).
        /// </summary>
        public override AssetType AssetType { get; set; }
        
        /// <summary>
        ///     Asset registration number (if any).
        /// </summary>
        public override string RegNumber { get; set; } = null!;
        
        /// <summary>
        ///     Security short name.
        /// </summary>
        public override string? ShortName { get; set; }
        
        /// <summary>
        ///     Security full name
        /// </summary>
        public override string? FullName { get; set; }
        
        /// <summary>
        ///     Risk group to which security belongs to.
        /// </summary>
        public override RiskType RiskType { get; set; }
        
        /// <summary>
        ///     Security notional.
        /// </summary>
        public override double? Notional { get; set; }
        
        /// <summary>
        ///     Currency of security's notional.
        /// </summary>
        public override string? Currency { get; set; }

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
        ///     Deposit expiration date.
        /// </summary>
        public DateTime? DepositExpirationDate { get; set; }
        
        /// <summary>
        ///     Current rate of deposit or REPO (in percent).
        /// </summary>
        public double? CurrentRate { get; set; }
        
        /// <summary>
        ///     Type of current deposit or REPO rate (fixed, floating, etc.)
        /// </summary>
        public string? RateType { get; set; }

        /// <summary>
        ///     Security best rating (if any).
        /// </summary>
        public string? InstrumentBestRating { get; set; }
        
        /// <summary>
        ///     Security best rating provider (if any).
        /// </summary>
        public string? InstrumentRatingAgency { get; set; }
        
        /// <summary>
        ///     Emitent best rating (if any).
        /// </summary>
        public string? EmitentBestRating { get; set; }
        
        /// <summary>
        ///     Emitent best rating provider (if any).
        /// </summary>
        public string? EmitentRatingAgency { get; set; }
        
        /// <summary>
        ///     Method of accounting for particular asset.
        /// </summary>
        public AccountingMethod AccountingMethod { get; set; }

        /// <summary>
        ///     Asset pricing type.
        /// </summary>
        public PriceFixationKind PriceFixation { get; set; }

        /// <summary>
        ///     Boolean flag to select all assets that priced at real prices.
        /// </summary>
        public bool UseRealPricing { get; set; }

        /// <summary>
        ///     Boolean flag to select all assets that priced at fair prices.
        /// </summary>0
        public bool UseFairPricing { get; set; }

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
        public override Security MarketInfo { get; set; } = null!;
        
        /// <summary>
        ///     Report source file information.
        /// </summary>
        /// <remarks>
        ///     Reflects one-to-many relationship (navigation property).
        /// </remarks>
        public override SourceFile Report { get; set; } = null!;
    }
}
