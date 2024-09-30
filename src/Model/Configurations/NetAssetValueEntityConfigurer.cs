using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentDataModel.Model.Configurations
{
    /// <summary>
    ///     Configures <see cref="NetAssetValue"/> entity for Entity Framework.
    /// </summary>
    public class NetAssetValueEntityConfigurer : IEntityTypeConfiguration<NetAssetValue>
    {
        public void Configure(EntityTypeBuilder<NetAssetValue> builder)
        {
            builder.ToTable("Portfolio-TEST2", "idep");
            builder.HasKey(ai => ai.LoadTime);


            builder.Property(sec => sec.AssetType)
                .HasConversion(at => at.ToString(),
                at => at.ToEnum<AssetType>())
                .HasColumnName("AssetType");

            builder.Property(sec => sec.AssetClass)
                .HasConversion(ac => ac.ToString(),
                ac => ac.ToEnum<AssetClass>())
                .HasColumnName("AssetClass");


            builder.Property(sec => sec.RiskType)
                .HasConversion(ac => ac.ToString(),
                ac => ac.ToEnum<RiskType>())
                .HasColumnName("RiskType");

            builder.Property(sec => sec.RegNumber)
            .HasColumnName("RegNumber");

            builder.Property(sec => sec.ShortName)
            .HasColumnName("ShortName");

            builder.Property(sec => sec.FullName)
            .HasColumnName("FullName");

            builder.Property(sec => sec.Notional)
            .HasColumnName("Notional");

            builder.Property(sec => sec.Currency)
            .HasColumnName("Currency");

            builder.Property(portf => portf.StrategyName)
            .HasColumnName("Strategy");

            builder.Property(portf => portf.PensionProperty)
            .HasConversion(et => et.ToString(),
            et => et.ToEnum<PensionPropertyType>())
            .HasColumnName("EntityType");

            builder.Property(portf => portf.Contract)
            .HasColumnName("Contract");

            builder.Ignore(portf => portf.RsNumber);

            builder.Property(issuer => issuer.Inn)
            .HasColumnName("INN");

            builder.Property(issuer => issuer.Name)
            .HasColumnName("Emitent");

            builder.OwnsOne(nav => nav.Pricing, owned =>
            {
                owned.Property(pi => pi.PriceFixation)
                .HasConversion(pt => pt.ToString(),
                    str => str.ToEnum<PriceFixationKind>())
                .HasColumnName("PriceFixation");

                owned.Property(ai => ai.UseRealPricing)
                .HasColumnName("UseRealPricing");

                owned.Property(ai => ai.UseFairPricing)
                .HasColumnName("UseFairPricing");
            });

            builder.Property(ai => ai.FundName)
            .HasColumnName("FundName");

            builder.Property(ai => ai.AmName)
            .HasColumnName("AmName");

            builder.Property(ai => ai.InstrumentBestRating)
            .HasColumnName("InstrumentBestRating");

            builder.Property(ai => ai.InstrumentRatingAgency)
            .HasColumnName("InstrumentRatingAgency");

            builder.Property(ai => ai.EmitentBestRating)
            .HasColumnName("EmitentBestRating");

            builder.Property(ai => ai.EmitentRatingAgency)
            .HasColumnName("EmitentRatingAgency");

            builder.Property(ai => ai.DepositExpirationDate)
            .HasColumnName("DepositExpirationDate");

            builder.Property(ai => ai.CurrentRate)
            .HasColumnName("CurrentRate");

            builder.Property(ai => ai.RateType)
            .HasColumnName("RateType");

            builder.Property(ai => ai.Isin)
            .HasColumnName("ISIN");

            builder.Property(ai => ai.AccountingMethod)
            .HasConversion(am => am.ToString(),
            am => am.ToEnum<AccountingMethod>());

            builder.Property(av => av.ReportName)
            .HasColumnName("SourceFile");

            builder.Property(av => av.ReportPricing)
            .HasConversion(rp => rp.ToString(),
            rpstr => rpstr.ToEnum<ReportPricingType>())
            .HasColumnName("SourcePricing");

            builder.HasOne(ai => ai.MarketInfo)
            .WithMany(si => si.Portfolio)
            .HasForeignKey(ai => ai.Isin)
            .HasPrincipalKey(si => si.Isin);

            builder.HasOne(av => av.Report)
            .WithMany(src => src.AssetRecords)
            .HasForeignKey(av => av.ReportName)
            .HasPrincipalKey(src => src.FileName);
        }
    }
}
