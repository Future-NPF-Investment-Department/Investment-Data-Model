using Efir.DataHub.Models.Models.Scoring;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentDataModel.Model.Configurations
{
    /// <summary>
    ///     Configures <see cref="Flow"/> builder for Entity Framework.
    /// </summary>
    public class FlowEntityConfigurer : IEntityTypeConfiguration<Flow>
    {
        public void Configure(EntityTypeBuilder<Flow> builder)
        {
            builder.ToTable("Flows-TEST2", "idep");
            builder.HasKey(flow => flow.LoadTime);

            builder.Property(ai => ai.FundName)
            .HasColumnName("FundName");

            builder.Property(ai => ai.AmName)
            .HasColumnName("AmName");


            builder.Property(portf => portf.StrategyName)
                .HasColumnName("Strategy");

            builder.Property(portf => portf.PensionProperty)
            .HasConversion(et => et.ToString(),
            et => et.ToEnum<PensionPropertyType>())
            .HasColumnName("EntityType");

            builder.Property(portf => portf.Contract)
            .HasColumnName("Contract");

            builder.Property(portf => portf.RsNumber)
            .HasColumnName("RsNumber");

            builder.Ignore(issuer => issuer.Inn);
            builder.Ignore(issuer => issuer.Name);

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
            .HasColumnName("AssetName");

            builder.Ignore(sec => sec.FullName);
            builder.Ignore(sec => sec.Notional);
            builder.Ignore(sec => sec.Currency);


            builder.Property(com => com.Comission)
                .HasColumnName("Comission");

            builder.Property(com => com.BrokerComission)
            .HasColumnName("BrokerComission");

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
