
namespace InvestmentDataModel
{
    /// <summary>
    ///     Information about commisions payed when any flow has occured.
    /// </summary>
    public class ComissionsEntry
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
