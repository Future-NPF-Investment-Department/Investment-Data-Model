using InvestmentData;
using InvestmentData.Classifications;
using InvestmentData.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentData.Context
{
    /// <summary>
    ///     Configures <see cref="AssetFlow"/> builder for Entity Framework.
    /// </summary>
    public class AssetFlowConfigurer : IEntityTypeConfiguration<AssetFlow>
    {
        public void Configure(EntityTypeBuilder<AssetFlow> builder)
        {
            builder.ToTable("Flows-TEST2", "idep");
            builder.HasKey(flow => flow.LoadTime);


            builder.OwnsOne(flow => flow.Fund, owned =>
            {
                owned.Property(ai => ai.FundName)
                .HasColumnName("FundName");

                owned.Property(ai => ai.AmName)
                .HasColumnName("AmName");
            });


            builder.OwnsOne(flow => flow.Portfolio, owned =>
            {
                owned.Property(portf => portf.StrategyName)
                .HasColumnName("Strategy");

                owned.Property(portf => portf.PensionProperty)
                .HasConversion(et => et.ToString(),
                et => et.ToEnum<PensionPropertyType>())
                .HasColumnName("EntityType");

                owned.Property(portf => portf.Contract)
                .HasColumnName("Contract");

                owned.Property(portf => portf.RsNumber)
                .HasColumnName("RsNumber");
            });


            builder.OwnsOne(flow => flow.Issuer, owned =>
            {
                owned.Ignore(issuer => issuer.Inn);
                owned.Ignore(issuer => issuer.Name);
            });


            builder.OwnsOne(flow => flow.Security, owned =>
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
                .HasColumnName("AssetName");

                owned.Ignore(sec => sec.FullName);
                owned.Ignore(sec => sec.Notional);
                owned.Ignore(sec => sec.Currency);
            });



            builder.OwnsOne(flow => flow.Comissions, owned =>
            {
                owned.Property(com => com.Comission)
                .HasColumnName("Comission");

                owned.Property(com => com.BrokerComission)
                .HasColumnName("BrokerComission");
            });


            builder.Property(flow => flow.Id)
           .HasColumnName("FlowId");


            builder.Property(flow => flow.Date)
           .HasColumnName("PayDate");


            builder.Property(flow => flow.TransType)
            .HasConversion(tt => tt.ToString(),
            str => str.ToEnum<TransType>());


            builder.HasOne(fi => fi.MarketInfo)
            .WithMany(si => si.Flows)
            .HasForeignKey(fi => fi.Isin)
            .HasPrincipalKey(si => si.Isin);


            builder.Property(av => av.ReportName)
            .HasColumnName("SourceFile");


            builder.HasOne(av => av.Report)
            .WithMany(src => src.FlowsRecords)
            .HasForeignKey(av => av.ReportName)
            .HasPrincipalKey(src => src.FileName);
        }
    }
}
