
namespace InvestmentDataModel
{
    /// <summary>
    ///     Security information.
    /// </summary>
    /// <remarks>
    ///     This type is owned by <see cref="AssetEntry"/> entity type.
    /// </remarks>
    public record SecurityInfoEntry
    {
        /// <summary>
        ///     Asset class (e.g. equities, bonds, cash etc.)
        /// </summary>
        public AssetClass AssetClass { get; set; }
        /// <summary>
        ///     Asset type (e.g. gov bonds, corp bonds, etc.).
        /// </summary>
        public AssetType AssetType { get; set; }
        /// <summary>
        ///     Asset registration number (if any).
        /// </summary>
        public string RegNumber { get; set; } = null!;
        /// <summary>
        ///     Security short name.
        /// </summary>
        public string? ShortName { get; set; }
        /// <summary>
        ///     Security full name
        /// </summary>
        public string? FullName { get; set; }
        /// <summary>
        ///     Risk group to which security belongs to.
        /// </summary>
        public RiskType RiskType { get; set; }
        /// <summary>
        ///     Security notional.
        /// </summary>
        public double? Notional { get; set; }
        /// <summary>
        ///     Currency of security's notional.
        /// </summary>
        public string? Currency { get; set; }
    }
}
