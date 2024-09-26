using Microsoft.EntityFrameworkCore;
using InvestmentData.Context.Entities;
using InvestmentDataContext.src.Context;

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
            modelBuilder
                .HasDbFunction(() => InvestmentDataExtensions.GetFlowDirection(default))
                .HasSchema("idep");

            modelBuilder.ApplyConfiguration(new AssetValueConfigurer());
            modelBuilder.ApplyConfiguration(new AssetFlowConfigurer());
            modelBuilder.ApplyConfiguration(new MarketInfoConfigurer());
            modelBuilder.ApplyConfiguration(new PriceFixationConfigurer());
            modelBuilder.ApplyConfiguration(new SourceFileConfigurer());
        }
    }
}
