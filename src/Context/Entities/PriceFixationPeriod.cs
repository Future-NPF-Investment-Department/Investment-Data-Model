namespace InvestmentDataModel.Context.Entities
{
    /// <summary>
    ///     Represents price fixation period information.
    /// </summary>
    public class PriceFixationInfo
    {
        /// <summary>
        ///     Name of Fund for which price fixation period exists.
        /// </summary>
        public string FundName { get; set; } = null!;
        /// <summary>
        ///     Date on which prices are fixed.
        /// </summary>
        public DateTime FixationDate { get; set; }
        /// <summary>
        ///     Start of price fixation period.
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        ///     End of price fixation period.
        /// </summary>
        public DateTime? End { get; set; }
        /// <summary>
        ///     Defines if specified date belongs to this fixation period.
        /// </summary>
        public bool ContainsDate(DateTime date)
        {
            if (End is null)
                return date >= Start;

            return date >= Start && date <= End;
        }
    }
}
