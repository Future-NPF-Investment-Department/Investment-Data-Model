using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentDataModel.Model.Configurations
{
    /// <summary>
    ///     Configures <see cref="SecurityEntry"/> entity for Entity Framework.
    /// </summary>
    public class MarketInfoConfigurer : IEntityTypeConfiguration<SecurityEntry>
    {
        public void Configure(EntityTypeBuilder<SecurityEntry> builder)
        {
            builder.ToTable("Securities", "idep");
            builder.HasKey(si => si.Isin);

            builder.Property(ai => ai.RiskType)
            .HasConversion(rt => rt.ToString(),
            rt => rt.ToEnum<RiskType>());

            builder.Property(ai => ai.AssetClass)
            .HasConversion(rt => rt.ToString(),
            rt => rt.ToEnum<AssetClass>());

            builder.Property(ai => ai.IssuerName)
            .HasColumnName("Issuer");

            builder.Property(ai => ai.Isin)
            .HasColumnName("ISIN");
        }
    }
}
