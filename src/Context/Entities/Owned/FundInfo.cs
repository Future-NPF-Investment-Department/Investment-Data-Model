using InvestmentDataModel.Context.Entities;

namespace InvestmentDataModel.Context.Entities.Owned
{
    /// <summary>
    ///     Fund information.
    /// </summary>
    /// <remarks>
    ///     This type is owned by <see cref="AssetValue"/> entity type.
    /// </remarks>
    public record FundInfo
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
