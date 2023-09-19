using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InvestmentData.Classifications
{
    /// <summary>
    ///     Represents the type of risk for particular asset (security) or strategy.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RiskType
    {
        NonRisk,
        Risk
    }
}
