
namespace InvestmentDataModel
{
    /// <summary>
    ///     Asset issuer information.
    /// </summary>
    /// <remarks>
    ///     This type is owned by <see cref="AssetEntry"/> entity type.
    /// </remarks>
    public record IssuerEntry
    {
        /// <summary>
        ///     Emitent name.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        ///     Emitent ID.
        /// </summary>
        public string? Inn { get; set; }
    }
}
