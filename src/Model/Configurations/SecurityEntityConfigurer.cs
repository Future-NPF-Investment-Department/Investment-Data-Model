using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentDataModel.Model.Configurations
{
    /// <summary>
    ///     Configures <see cref="Security"/> entity for Entity Framework.
    /// </summary>
    public class SecurityEntityConfigurer : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
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
