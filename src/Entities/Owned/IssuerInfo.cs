namespace InvestmentDataContext.Entities.Owned
{
    /// <summary>
    ///     Asset issuer information.
    /// </summary>
    /// <remarks>
    ///     This type is owned by <see cref="AssetValue"/> entity type.
    /// </remarks>
    public record IssuerInfo
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
