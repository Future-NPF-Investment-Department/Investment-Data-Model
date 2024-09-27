
namespace InvestmentDataModel
{
    /// <summary>
    ///     Fund information.
    /// </summary>
    /// <remarks>
    ///     This type is owned by <see cref="AssetEntry"/> entity type.
    /// </remarks>
    public record FundInfoEntry
    {
        /// <summary>
        /// Name of fund.
        /// </summary>
        public string FundName { get; set; } = null!;
        /// <summary>
        /// Asset management company name.
        /// </summary>
        public string AmName { get; set; } = null!;
    }
}
