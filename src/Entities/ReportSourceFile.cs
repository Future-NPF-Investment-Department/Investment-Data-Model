using InvestmentDataContext.Classifications;

namespace InvestmentDataContext.Entities
{
    /// <summary>
    ///     Represents report source file information.
    /// </summary>
    public class ReportSourceFile
    {
        /// <summary>
        ///     Provider of report file. Specifically this is Asset Management company name.
        /// </summary>
        public string Provider { get; set; } = null!;
        /// <summary>
        ///     File name without full path.
        /// </summary>
        public string FileName { get; set; } = null!;
        /// <summary>
        ///     File name including full path.
        /// </summary>
        public string FullPath { get; set; } = null!;
        /// <summary>
        ///     Date on which the report was compiled.
        /// </summary>
        public DateTime ReportDate { get; set; }
        /// <summary>
        ///     Prices used in report source file.
        /// </summary>
        public ReportPricingType PricingType { get; set; }    
        /// <summary>
        ///     Name of table to shich records were loaded. 
        /// </summary>
        public string Destination { get; set; } = null!;
        /// <summary>
        ///     Time when report was loaded to database.
        /// </summary>
        public DateTime LoadTime { get; set; }
        /// <summary>
        ///     Corresponding collection of asset records in this report source file.   
        /// </summary>
        /// <remarks>
        ///     Reflects one-to-many relationship (navigation property) with on-delete-cascade constraint.
        /// </remarks>
        public virtual ICollection<AssetValue> AssetRecords { get; set; } = null!;
        /// <summary>
        ///     Corresponding collection of flows records in this report source file.   
        /// </summary>
        /// <remarks>
        ///     Reflects one-to-many relationship (navigation property) with on-delete-cascade constraint.
        /// </remarks>
        public virtual ICollection<AssetFlow> FlowsRecords { get; set; } = null!;

        public static implicit operator string (ReportSourceFile reportSourceFile)
            => reportSourceFile.FullPath;
    }
}
