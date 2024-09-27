using InvestmentDataModel.Classifications;
using InvestmentDataModel.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentDataModel.Context
{
    /// <summary>
    ///     Configures <see cref="ReportSourceFile"/> entity for Entity Framework.
    /// </summary>
    public class SourceFileConfigurer : IEntityTypeConfiguration<ReportSourceFile>
    {
        public void Configure(EntityTypeBuilder<ReportSourceFile> builder)
        {
            builder.ToTable("Reports", "idep");
            builder.HasKey(rep => rep.Id);
            builder.HasAlternateKey(rep => rep.FileName);

            builder.Property(rep => rep.FileDirectoryName)
            .HasColumnName("FullPath");

            builder.Property(rep => rep.PricingType)
            .HasConversion(pt => pt.ToString(),
            str => str.ToEnum<ReportPricingType>());

            builder.Property(rep => rep.Destination)
            .HasConversion(pt => pt.ToString(),
            str => str.ToEnum<SqlTargetTable>());
        }
    }
}
