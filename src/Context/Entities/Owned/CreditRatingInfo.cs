using InvestmentData.Context.Entities;

namespace InvestmentData.Context.Entities.Owned
{
    /// <summary>
    ///     Information regarding creditworthiness of particular asset.
    /// </summary>
    /// <remarks>
    ///     This type is owned by <see cref="AssetValue"/> entity type.
    /// </remarks>
    public record CreditRatingInfo
    {
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
        ///     Security best rating provider (if any).
        /// </summary>
        public string? EmitentRatingAgency { get; set; }
    }
}
