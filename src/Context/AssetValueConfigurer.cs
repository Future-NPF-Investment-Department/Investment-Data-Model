using InvestmentData;
using InvestmentData.Classifications;
using InvestmentData.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentData.Context
{
    /// <summary>
    ///     Configures <see cref="AssetValue"/> entity for Entity Framework.
    /// </summary>
    public class AssetValueConfigurer : IEntityTypeConfiguration<AssetValue>
    {
        public void Configure(EntityTypeBuilder<AssetValue> builder)
        {
            builder.ToTable("Portfolio-TEST2", "idep");
            builder.HasKey(ai => ai.LoadTime);


            builder.OwnsOne(nav => nav.Security, owned =>
            {
                owned.Property(sec => sec.AssetType)
                .HasConversion(at => at.ToString(),
                at => at.ToEnum<AssetType>())
                .HasColumnName("AssetType");

                owned.Property(sec => sec.AssetClass)
                .HasConversion(ac => ac.ToString(),
                ac => ac.ToEnum<AssetClass>())
                .HasColumnName("AssetClass");

                owned.Property(sec => sec.RiskType)
                .HasConversion(ac => ac.ToString(),
                ac => ac.ToEnum<RiskType>())
                .HasColumnName("RiskType");

                owned.Property(sec => sec.RegNumber)
                .HasColumnName("RegNumber");

                owned.Property(sec => sec.ShortName)
                .HasColumnName("ShortName");

                owned.Property(sec => sec.FullName)
                .HasColumnName("FullName");

                owned.Property(sec => sec.Notional)
                .HasColumnName("Notional");

                owned.Property(sec => sec.Currency)
                .HasColumnName("Currency");
            });


            builder.OwnsOne(nav => nav.Portfolio, owned =>
            {
                owned.Property(portf => portf.StrategyName)
                .HasColumnName("Strategy");

                owned.Property(portf => portf.PensionProperty)
                .HasConversion(et => et.ToString(),
                et => et.ToEnum<PensionPropertyType>())
                .HasColumnName("EntityType");

                owned.Property(portf => portf.Contract)
                .HasColumnName("Contract");

                owned.Ignore(portf => portf.RsNumber);
            });


            builder.OwnsOne(nav => nav.Issuer, owned =>
            {
                owned.Property(issuer => issuer.Inn)
                .HasColumnName("INN");

                owned.Property(issuer => issuer.Name)
                .HasColumnName("Emitent");
            });


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


            builder.OwnsOne(nav => nav.Fund, owned =>
            {
                owned.Property(ai => ai.FundName)
                .HasColumnName("FundName");

                owned.Property(ai => ai.AmName)
                .HasColumnName("AmName");
            });



            builder.OwnsOne(nav => nav.CreditRating, owned =>
            {
                owned.Property(ai => ai.InstrumentBestRating)
                .HasColumnName("InstrumentBestRating");

                owned.Property(ai => ai.InstrumentRatingAgency)
                .HasColumnName("InstrumentRatingAgency");

                owned.Property(ai => ai.EmitentBestRating)
                .HasColumnName("EmitentBestRating");

                owned.Property(ai => ai.EmitentRatingAgency)
                .HasColumnName("EmitentRatingAgency");
            });


            builder.OwnsOne(nav => nav.Interest, owned =>
            {
                owned.Property(ai => ai.DepositExpirationDate)
                .HasColumnName("DepositExpirationDate");

                owned.Property(ai => ai.CurrentRate)
                .HasColumnName("CurrentRate");

                owned.Property(ai => ai.RateType)
                .HasColumnName("RateType");
            });



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
