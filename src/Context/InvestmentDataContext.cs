using InvestmentData.SqlServer;
using Microsoft.EntityFrameworkCore;
using InvestmentData.Context.Entities;

namespace InvestmentData.Context
{
    public class InvestmentDataContext : DbContext
    {
        public const string DFLTCONNSTR 
            = "Server=(localdb)\\mssqllocaldb;Database=InvestmentDataBase-Test;Trusted_Connection=True;Integrated Security=True;";
        private readonly string? _connString;

        public InvestmentDataContext() : base()
        {
        }

        public InvestmentDataContext(string connString) : base()
            => _connString = connString;

        public InvestmentDataContext(DbContextOptions<InvestmentDataContext> options) : base(options)
        {
        }

        public virtual DbSet<ReferenceMarketInfo> Securities { get; set; } = null!;
        public virtual DbSet<AssetFlow> Flows { get; set; } = null!;
        public virtual DbSet<AssetValue> Assets { get; set; }
        public virtual DbSet<ReportSourceFile> Reports { get; set; } = null!;
        public virtual DbSet<PriceFixationInfo> FixationPeriods { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(_connString ?? DFLTCONNSTR);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(() => IdepSqlFunctions.GetFlowDirection(default))
                .HasSchema("idep");

            modelBuilder.ApplyConfiguration(new AssetValueConfigurer());
            modelBuilder.ApplyConfiguration(new AssetFlowConfigurer());
            modelBuilder.ApplyConfiguration(new MarketInfoConfigurer());
            modelBuilder.ApplyConfiguration(new PriceFixationConfigurer());
            modelBuilder.ApplyConfiguration(new SourceFileConfigurer());


            //modelBuilder.Entity<AssetValue>(entity =>
            //{
            //    entity.ToTable("Portfolio-TEST2", "idep");
            //    entity.HasKey(ai => ai.LoadTime);


            //    entity.OwnsOne(nav => nav.Security, owned =>
            //    {
            //        owned.Property(sec => sec.AssetType)
            //        .HasConversion(at => at.ToString(),
            //        at => at.ToEnum<AssetType>())
            //        .HasColumnName("AssetType");

            //        owned.Property(sec => sec.AssetClass)
            //        .HasConversion(ac => ac.ToString(),
            //        ac => ac.ToEnum<AssetClass>())
            //        .HasColumnName("AssetClass");

            //        owned.Property(sec => sec.RiskType)
            //        .HasConversion(ac => ac.ToString(),
            //        ac => ac.ToEnum<RiskType>())
            //        .HasColumnName("RiskType");

            //        owned.Property(sec => sec.RegNumber)
            //        .HasColumnName("RegNumber");

            //        owned.Property(sec => sec.ShortName)
            //        .HasColumnName("ShortName");

            //        owned.Property(sec => sec.FullName)
            //        .HasColumnName("FullName");

            //        owned.Property(sec => sec.Notional)
            //        .HasColumnName("Notional");

            //        owned.Property(sec => sec.Currency)
            //        .HasColumnName("Currency");
            //    });


            //    entity.OwnsOne(nav => nav.Portfolio, owned =>
            //    {
            //        owned.Property(portf => portf.StrategyName)
            //        .HasColumnName("Strategy");

            //        owned.Property(portf => portf.PensionProperty)
            //        .HasConversion(et => et.ToString(),
            //        et => et.ToEnum<PensionPropertyType>())
            //        .HasColumnName("EntityType");

            //        owned.Property(portf => portf.Contract)
            //        .HasColumnName("Contract");

            //        owned.Ignore(portf => portf.RsNumber);
            //    });


            //    entity.OwnsOne(nav => nav.Issuer, owned =>
            //    {
            //        owned.Property(issuer => issuer.Inn)
            //        .HasColumnName("INN");

            //        owned.Property(issuer => issuer.Name)
            //        .HasColumnName("Emitent");
            //    });


            //    entity.OwnsOne(nav => nav.Pricing, owned =>
            //    {
            //        owned.Property(pi => pi.PriceFixation)
            //        .HasConversion(pt => pt.ToString(),
            //            str => str.ToEnum<PriceFixationKind>())
            //        .HasColumnName("PriceFixation");

            //        owned.Property(ai => ai.UseRealPricing)
            //        .HasColumnName("UseRealPricing");

            //        owned.Property(ai => ai.UseFairPricing)
            //        .HasColumnName("UseFairPricing");
            //    });


            //    entity.OwnsOne(nav => nav.Fund, owned =>
            //    {
            //        owned.Property(ai => ai.FundName)
            //        .HasColumnName("FundName");

            //        owned.Property(ai => ai.AmName)
            //        .HasColumnName("AmName");
            //    });



            //    entity.OwnsOne(nav => nav.CreditRating, owned =>
            //    {
            //        owned.Property(ai => ai.InstrumentBestRating)
            //        .HasColumnName("InstrumentBestRating");

            //        owned.Property(ai => ai.InstrumentRatingAgency)
            //        .HasColumnName("InstrumentRatingAgency");

            //        owned.Property(ai => ai.EmitentBestRating)
            //        .HasColumnName("EmitentBestRating");

            //        owned.Property(ai => ai.EmitentRatingAgency)
            //        .HasColumnName("EmitentRatingAgency");
            //    });


            //    entity.OwnsOne(nav => nav.Interest, owned =>
            //    {
            //        owned.Property(ai => ai.DepositExpirationDate)
            //        .HasColumnName("DepositExpirationDate");

            //        owned.Property(ai => ai.CurrentRate)
            //        .HasColumnName("CurrentRate");

            //        owned.Property(ai => ai.RateType)
            //        .HasColumnName("RateType");
            //    });



            //    entity.Property(ai => ai.Isin)
            //    .HasColumnName("ISIN");


            //    entity.Property(ai => ai.AccountingMethod)
            //    .HasConversion(am => am.ToString(),
            //    am => am.ToEnum<AccountingMethod>());


            //    entity.Property(av => av.ReportName)
            //    .HasColumnName("SourceFile");


            //    entity.Property(av => av.ReportPricing)
            //    .HasConversion(rp => rp.ToString(),
            //    rpstr => rpstr.ToEnum<ReportPricingType>())
            //    .HasColumnName("SourcePricing");


            //    entity.HasOne(ai => ai.MarketInfo)
            //    .WithMany(si => si.Portfolio)
            //    .HasForeignKey(ai => ai.Isin)
            //    .HasPrincipalKey(si => si.Isin);


            //    entity.HasOne(av => av.Report)
            //    .WithMany(src => src.AssetRecords)
            //    .HasForeignKey(av => av.ReportName)
            //    .HasPrincipalKey(src => src.FileName);

            //});

            //modelBuilder.Entity<AssetFlow>(entity =>
            //{
            //    entity.ToTable("Flows-TEST2", "idep");
            //    entity.HasKey(flow => flow.LoadTime);


            //    entity.OwnsOne(flow => flow.Fund, owned =>
            //    {
            //        owned.Property(ai => ai.FundName)
            //        .HasColumnName("FundName");

            //        owned.Property(ai => ai.AmName)
            //        .HasColumnName("AmName");
            //    });


            //    entity.OwnsOne(flow => flow.Portfolio, owned =>
            //    {
            //        owned.Property(portf => portf.StrategyName)
            //        .HasColumnName("Strategy");

            //        owned.Property(portf => portf.PensionProperty)
            //        .HasConversion(et => et.ToString(),
            //        et => et.ToEnum<PensionPropertyType>())
            //        .HasColumnName("EntityType");

            //        owned.Property(portf => portf.Contract)
            //        .HasColumnName("Contract");

            //        owned.Property(portf => portf.RsNumber)
            //        .HasColumnName("RsNumber");
            //    });


            //    entity.OwnsOne(flow => flow.Issuer, owned =>
            //    {
            //        owned.Ignore(issuer => issuer.Inn);
            //        owned.Ignore(issuer => issuer.Name);
            //    });


            //    entity.OwnsOne(flow => flow.Security, owned =>
            //    {
            //        owned.Property(sec => sec.AssetType)
            //        .HasConversion(at => at.ToString(),
            //        at => at.ToEnum<AssetType>())
            //        .HasColumnName("AssetType");

            //        owned.Property(sec => sec.AssetClass)
            //        .HasConversion(ac => ac.ToString(),
            //        ac => ac.ToEnum<AssetClass>())
            //        .HasColumnName("AssetClass");

            //        owned.Property(sec => sec.RiskType)
            //        .HasConversion(ac => ac.ToString(),
            //        ac => ac.ToEnum<RiskType>())
            //        .HasColumnName("RiskType");

            //        owned.Property(sec => sec.RegNumber)
            //        .HasColumnName("RegNumber");

            //        owned.Property(sec => sec.ShortName)
            //        .HasColumnName("AssetName");

            //        owned.Ignore(sec => sec.FullName);
            //        owned.Ignore(sec => sec.Notional);
            //        owned.Ignore(sec => sec.Currency);
            //    });



            //    entity.OwnsOne(flow => flow.Comissions, owned =>
            //    {
            //        owned.Property(com => com.Comission)
            //        .HasColumnName("Comission");

            //        owned.Property(com => com.BrokerComission)
            //        .HasColumnName("BrokerComission");
            //    });


            //    entity.Property(flow => flow.Id)
            //   .HasColumnName("FlowId");


            //    entity.Property(flow => flow.Date)
            //   .HasColumnName("PayDate");


            //    entity.Property(flow => flow.TransType)
            //    .HasConversion(tt => tt.ToString(),
            //    str => str.ToEnum<TransType>());


            //    entity.HasOne(fi => fi.MarketInfo)
            //    .WithMany(si => si.Flows)
            //    .HasForeignKey(fi => fi.Isin)
            //    .HasPrincipalKey(si => si.Isin);


            //    entity.Property(av => av.ReportName)
            //    .HasColumnName("SourceFile");


            //    entity.HasOne(av => av.Report)
            //    .WithMany(src => src.FlowsRecords)
            //    .HasForeignKey(av => av.ReportName)
            //    .HasPrincipalKey(src => src.FileName);


            //});

            //modelBuilder.Entity<ReferenceMarketInfo>(entity =>
            //{
            //    entity.ToTable("Securities", "idep");
            //    entity.HasKey(si => si.Isin);

            //    entity.Property(ai => ai.RiskType)
            //    .HasConversion(rt => rt.ToString(),
            //    rt => rt.ToEnum<RiskType>());

            //    entity.Property(ai => ai.AssetClass)
            //    .HasConversion(rt => rt.ToString(),
            //    rt => rt.ToEnum<AssetClass>());

            //    entity.Property(ai => ai.IssuerName)
            //    .HasColumnName("Issuer");

            //    entity.Property(ai => ai.Isin)
            //    .HasColumnName("ISIN");
            //});

            //modelBuilder.Entity<ReportSourceFile>(entity =>
            //{
            //    entity.ToTable("Reports", "idep");
            //    entity.HasKey(rep => rep.Id);
            //    entity.HasAlternateKey(rep => rep.FileName);

            //    entity.Property(rep => rep.FileDirectoryName)
            //    .HasColumnName("FullPath");

            //    entity.Property(rep => rep.PricingType)
            //    .HasConversion(pt => pt.ToString(),
            //    str => str.ToEnum<ReportPricingType>());

            //    entity.Property(rep => rep.Destination)
            //    .HasConversion(pt => pt.ToString(),
            //    str => str.ToEnum<SqlTargetTable>());

            //    entity.Ignore(rep => rep.CsvMapping);
            //});

            //modelBuilder.Entity<PriceFixationInfo>(entity =>
            //{
            //    entity.ToTable("PriceFixations", "idep");
            //    entity.HasKey(pfi => new { pfi.FundName, pfi.FixationDate });
            //});
        }
    }
}
