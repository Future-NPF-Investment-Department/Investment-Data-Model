
namespace InvestmentDataModel
{
    /// <summary>
    ///     Represents flow of specific asset at particular date.
    /// </summary>
    public class Flow : InvestDataEntryBase
    {
        /// <summary>
        ///     Trade ID.
        /// </summary>
        public long? Id { get; set; }

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
        ///     Asset ISIN code (if any).
        /// </summary>
        public override string? Isin { get; set; } = null!;
        
        /// <summary>
        ///     Date of flow originated.
        /// </summary>
        public DateTime? OperationDate { get; set; }
        
        /// <summary>
        ///     Date on which real flow occured.
        /// </summary>
        public override DateTime Date { get; set; }
        
        /// <summary>
        ///     Type of flow transaction
        /// </summary>
        public TransType TransType { get; set; }
        
        /// <summary>
        ///     Total net value of particular flow at pay date. 
        /// </summary>
        public override double? NetValue { get; set; }
        
        /// <summary>
        ///     Total accrued interest of particular asset at pay date. 
        /// </summary>
        public override double? AccruedInterest { get; set; }
        
        /// <summary>
        ///     Total full value of particular flow at pay date.
        /// </summary>
        public override double FullValue { get; set; }
        
        /// <summary>
        ///     Quantity of particular asset in flow that took place at pay date.
        /// </summary>
        public override double? Amount { get; set; }

        /// <summary>
        ///     Flow commission charged by the exchange.
        /// </summary>
        public double? Comission { get; set; }
        /// <summary>
        ///     Flow commission charged by the broker.
        /// </summary>
        public double? BrokerComission { get; set; }

        /// <summary>
        ///     Additional information regarding the nature of the flow.
        /// </summary>
        public string? Comment { get; set; }
        
        /// <summary>
        ///     Load time (instance creation time in fact).
        /// </summary>
        public DateTime LoadTime { get; set; } = DateTime.Now;
        
        /// <summary>
        ///     Source file full name.
        /// </summary>
        public string ReportName { get; set; } = null!;
        
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
