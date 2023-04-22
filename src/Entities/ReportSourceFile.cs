using InvestmentDataContext.Classifications;

namespace InvestmentDataContext.Entities
{
    public class ReportSourceFile
    {
        public string Provider { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string FullPath { get; set; } = null!;
        public DateTime ReportDate { get; set; }  
        public ReportPricingType PricingType { get; set; }    
        public string Destination { get; set; } = null!;

        public virtual ICollection<AssetValue> AssetRecords { get; set; } = null!;
        public virtual ICollection<AssetFlow> FlowsRecords { get; set; } = null!;

        public static implicit operator string (ReportSourceFile reportSourceFile)
            => reportSourceFile.FileName;
    }
}
