using InvestmentData.Classifications;
using InvestmentData.Context.Entities;
using InvestmentDataContext.src.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentData.Context
{
    /// <summary>
    ///     Configures <see cref="ReferenceMarketInfo"/> entity for Entity Framework.
    /// </summary>
    public class MarketInfoConfigurer : IEntityTypeConfiguration<ReferenceMarketInfo>
    {
        public void Configure(EntityTypeBuilder<ReferenceMarketInfo> builder)
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
