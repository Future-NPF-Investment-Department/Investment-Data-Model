using CsvHelper.Configuration;
using InvestmentDataContext.Classifications;
using System.Text;


namespace InvestmentDataContext
{
    public class ReportLoadingContext
    {
        public string FileProvider { get; set; } = null!;
        public ReportPricingType ReportPricingType { get; set; }
        public SqlTargetTable SqlTargetTable { get; set; }
        public Mapper Mappings { get; set; } = null!;
        public CsvConfiguration CsvConfiguration { get; set; } = null!;
        public Encoding Encoding { get; set; } = null!;
    }
}
