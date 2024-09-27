using Microsoft.EntityFrameworkCore;
using InvestmentDataModel.Model.Configurations;

namespace InvestmentDataModel
{
    public class InvestData : DbContext
    {
        public const string DFLTCONNSTR
            = "Server=(localdb)\\mssqllocaldb;Database=InvestmentDataBase-Test;Trusted_Connection=True;Integrated Security=True;";
        private readonly string? _connString;

        public InvestData() : base()
        {
        }

        public InvestData(string connString) : base()
            => _connString = connString;

        public InvestData(DbContextOptions<InvestData> options) : base(options)
        {
        }

        public virtual DbSet<FlowEntry> Flows { get; set; } = null!;
        public virtual DbSet<AssetEntry> Assets { get; set; }
        public virtual DbSet<ReportSourceFile> Reports { get; set; } = null!;
        public virtual DbSet<SecurityEntry> Securities { get; set; } = null!;
        public virtual DbSet<PriceFixationEntry> FixationPeriods { get; set; } = null!;



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
                .HasDbFunction(() => InvestDataExtensions.GetFlowDirection(default))
                .HasSchema("idep");

            modelBuilder.ApplyConfiguration(new AssetValueConfigurer());
            modelBuilder.ApplyConfiguration(new AssetFlowConfigurer());
            modelBuilder.ApplyConfiguration(new MarketInfoConfigurer());
            modelBuilder.ApplyConfiguration(new PriceFixationConfigurer());
            modelBuilder.ApplyConfiguration(new SourceFileConfigurer());
        }
    }
}
