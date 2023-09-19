
namespace InvestmentData.Context.Entities.Owned
{
    /// <summary>
    ///     Information regarding interest-based assets.
    /// </summary>
    /// <remarks>
    ///     This type is owned by <see cref="AssetValue"/> entity type.
    /// </remarks>
    public record InterestRateInfo
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
