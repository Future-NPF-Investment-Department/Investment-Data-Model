using InvestmentDataModel.Classifications;
using InvestmentDataModel.Context.Entities.Owned;

namespace InvestmentDataModel.Context.Entities
{
    /// <summary>
    ///     Represents flow of specific asset at particular date.
    /// </summary>
    public class AssetFlow : InvestmentDataRecord
    {
        /// <summary>
        ///     Trade ID.
        /// </summary>
        public long? Id { get; set; }
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
        ///     Information about security that represents specific asset.
        /// </summary>
        public override SecurityInfo Security { get; set; } = null!;
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
        ///     Information regarding commisions that were payed when flow occured.
        /// </summary>
        public ComissionInfo Comissions { get; set; } = null!;
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
