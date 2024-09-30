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

        public virtual DbSet<Flow> Flows { get; set; } = null!;
        public virtual DbSet<NetAssetValue> Assets { get; set; }
        public virtual DbSet<SourceFile> Reports { get; set; } = null!;
        public virtual DbSet<Security> Securities { get; set; } = null!;
        public virtual DbSet<PriceFixationPeriod> FixationPeriods { get; set; } = null!;



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

            modelBuilder.ApplyConfiguration(new NetAssetValueEntityConfigurer());
            modelBuilder.ApplyConfiguration(new FlowEntityConfigurer());
            modelBuilder.ApplyConfiguration(new SecurityEntityConfigurer());
            modelBuilder.ApplyConfiguration(new PriceFixationPeriodEntityConfigurer());
            modelBuilder.ApplyConfiguration(new SourceFileEntityConfigurer());
        }
    }
}
