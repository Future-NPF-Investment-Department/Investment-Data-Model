namespace InvestmentData.Context.Entities.Owned
{
    /// <summary>
    ///     Information about commisions payed when any flow has occured.
    /// </summary>
    public class ComissionInfo
    {
        /// <summary>
        ///     Flow commission charged by the exchange.
        /// </summary>
        public double? Comission { get; set; }
        /// <summary>
        ///     Flow commission charged by the broker.
        /// </summary>
        public double? BrokerComission { get; set; }
    }
}
