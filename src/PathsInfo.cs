using InvestmentDataContext.Classifications;

namespace InvestmentDataContext
{
    public class PathsInfo
    {
        /// <summary>
        ///     
        /// </summary>
        public List<string> Paths { get; set; } = null!;
        /// <summary>
        ///     File-path -> provider-mame mapping (JSON serialized).
        /// </summary>  
        public Dictionary<string, string> ProviderFlags { get; set; } = null!;
        /// <summary>
        ///     File-path -> pricing-type mapping (JSON serialized).
        /// </summary>
        public Dictionary<string, ReportPricingType> PricingFlags { get; set; } = null!;
        /// <summary>
        ///     File-path -> SQL-target-table mapping (JSON serialized).
        /// </summary>
        public Dictionary<string, SqlTargetTable> SqlTargetFlags { get; set; } = null!;

        public void Add(string path, string fileProvider, ReportPricingType pricing, SqlTargetTable targetTable)
        {
            if (Paths.Contains(path))
                throw new Exception($"Cannot register path '{path}' as is is already registered.");
            
            Paths.Add(path);
            ProviderFlags.Add(path, fileProvider);
            PricingFlags.Add(path, pricing);
            SqlTargetFlags.Add(path, targetTable);
        }
    }
}
