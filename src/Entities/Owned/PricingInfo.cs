using InvestmentDataContext.Classifications;

namespace InvestmentDataContext.Entities.Owned
{
    /// <summary>
    ///     Asset pricing information.
    /// </summary>
    /// <remarks>
    ///     This type is owned by <see cref="AssetValue"/> entity type.
    /// </remarks>
    public record PricingInfo
    {
        /// <summary>
        ///     Asset pricing type.
        /// </summary>
        public PricingType PricingType { get; set; }
        /// <summary>
        ///     Boolean flag to select all assets that priced at real prices.
        /// </summary>
        public bool UseRealPricing { get; set; }
        /// <summary>
        ///     Boolean flag to select all assets that priced at fair prices.
        /// </summary>
        public bool UseFairPricing { get; set; }
    }
}
