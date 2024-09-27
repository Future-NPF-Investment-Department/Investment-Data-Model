
namespace InvestmentDataModel
{
    /// <summary>
    ///     Investment portfolio information.
    /// </summary>
    /// <remarks>
    ///     This type is owned by <see cref="AssetValue"/> entity type.
    /// </remarks>
    public record PortfolioInfo
    {
        /// <summary>
        ///     Type of pension property.
        /// </summary>
        public PensionPropertyType PensionProperty { get; set; }
        /// <summary>
        ///     Strategy name.
        /// </summary>
        public string StrategyName { get; set; } = null!;
        /// <summary>
        ///     Contract ID.
        /// </summary>
        public string Contract { get; set; } = null!;
        /// <summary>
        ///     Current account ID.
        /// </summary>
        public string? RsNumber { get; set; }
    }
}
