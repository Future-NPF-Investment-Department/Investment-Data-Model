using Microsoft.EntityFrameworkCore;
using InvestmentDataModel.Model.Configurations;

namespace InvestmentDataModel
{
    public class InvestData : DbContext
    {
        private InvestData(DbContextOptions options) : base(options) { }

        public virtual DbSet<NetAssetValue> Assets { get; set; }
        public virtual DbSet<Flow> Flows { get; set; } = null!;
        public virtual DbSet<Security> Securities { get; set; } = null!;
        public virtual DbSet<PriceFixationPeriod> FixationPeriods { get; set; } = null!;
        public virtual DbSet<SourceFile> Reports { get; set; } = null!;

        public static InvestData ConfigureForSQLServer(string connectionString)
        {
            var options = new DbContextOptionsBuilder<InvestData>()
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies()
                .Options;

            return new InvestData(options);
        }

        public static InvestData ConfigureForSQLite(string connectionString)
        {
            var options = new DbContextOptionsBuilder<InvestData>()
                .UseSqlite(connectionString)
                .UseLazyLoadingProxies()
                .Options;

            return new InvestData(options);
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
