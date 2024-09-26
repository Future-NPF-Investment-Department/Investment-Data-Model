using InvestmentData.Classifications;

namespace InvestmentData.Context.Entities
{
    /// <summary>
    ///     Represents report source file (.csv) information.
    /// </summary>
    public class ReportSourceFile : IEquatable<ReportSourceFile?>
    {
        //private readonly string _fileDirecory;
        public ReportSourceFile() { }
        private ReportSourceFile(FileInfo file, string provider, ReportPricingType pricing, SqlTargetTable destination)
        {
            //_fileDirecory = file.DirectoryName ?? string.Empty;
            FileName = file.Name;
            FileDirectoryName = file.DirectoryName!;
            PricingType = pricing;
            Provider = provider;
            Destination = destination;
        }

        /// <summary>
        ///     Report identifier.
        /// </summary>
        public int Id { get; set; }
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
        public string FileDirectoryName { get; set; } = null!;
        /// <summary>
        ///     Date on which the report was compiled.
        /// </summary>
        public DateTime? ReportDate { get; set; }
        /// <summary>
        ///     Prices used in report source file.
        /// </summary>
        public ReportPricingType PricingType { get; set; }
        /// <summary>
        ///     Number of records in file.
        /// </summary>
        public int RecordsNumber { get; set; }
        /// <summary>
        ///     Target table to which records were loaded.
        /// </summary>
        public SqlTargetTable Destination { get; set; }
        /// <summary>
        ///     Time when report was loaded to database.
        /// </summary>
        public DateTime LoadTime { get; set; } = DateTime.Now;
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

        /// <summary>
        ///     Creates new instance of <see cref="ReportSourceFile"/>.
        /// </summary>
        public static ReportSourceFile New(FileInfo file, PathsInfo pathsInfo)
        {
            if (file.Directory is null) throw new Exception("");
            ReportPricingType pricing = pathsInfo.PricingFlags[file.Directory!.FullName];
            SqlTargetTable destination = pathsInfo.SqlTargetFlags[file.Directory!.FullName];
            string provider = pathsInfo.ProviderFlags[file.Directory!.FullName];
            return new ReportSourceFile(file, provider, pricing, destination);
        }

        public static ReportSourceFile New(FileInfo file, string fileProvifer, ReportPricingType pricing, SqlTargetTable destination)
        {
            if (file.Directory is null) throw new Exception("");
            return new ReportSourceFile(file, fileProvifer, pricing, destination);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ReportSourceFile);
        }

        public bool Equals(ReportSourceFile? other)
        {
            return other is not null &&
                   FileDirectoryName == other.FileDirectoryName &&
                   ReportDate == other.ReportDate &&
                   PricingType == other.PricingType &&
                   Destination == other.Destination;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FileDirectoryName, ReportDate, PricingType, Destination);
        }
    }
}
