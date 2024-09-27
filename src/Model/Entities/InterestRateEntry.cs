
namespace InvestmentDataModel
{
    /// <summary>
    ///     Information regarding interest-based assets.
    /// </summary>
    /// <remarks>
    ///     This type is owned by <see cref="AssetEntry"/> entity type.
    /// </remarks>
    public record InterestRateEntry
    {
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
    }
}
