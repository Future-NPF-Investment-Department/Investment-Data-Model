using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InvestmentData.Classifications
{
    /// <summary>
    ///     Represents SQL target table for data loaded/fetched. 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SqlTargetTable
    {
        Portfolio,
        Flows
    }
}
