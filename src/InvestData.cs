using Microsoft.EntityFrameworkCore;
using InvestmentDataModel.Model.Configurations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InvestmentDataModel
{
    /// <summary>
    ///     Контекст инвест. данных. для взаимодействия с базой данных.
    /// </summary>
    public class InvestData : DbContext
    {
        private InvestData(DbContextOptions options) : base(options) { }

        /// <summary>
        ///     Таблица стоимости чистых активов.
        /// </summary>
        public virtual DbSet<NetAssetValue> Assets { get; set; }

        /// <summary>
        ///     Таблица потоков.
        /// </summary>
        public virtual DbSet<Flow> Flows { get; set; } = null!;

        /// <summary>
        ///     Таблица параметров ценных бумаг, находящихся в портфелях НПФ.
        /// </summary>
        public virtual DbSet<Security> Securities { get; set; } = null!;

        /// <summary>
        ///     Таблица периодов фиксации цен.
        /// </summary>
        public virtual DbSet<PriceFixationPeriod> FixationPeriods { get; set; } = null!;

        /// <summary>
        ///     Таблица загруженных отчетов.
        /// </summary>
        public virtual DbSet<SourceFile> Reports { get; set; } = null!;


        /// <summary>
        ///     Создает контекст инвест данных, настроенный под SQL Server.
        /// </summary>
        public static InvestData ConfigureForSQLServer(string connectionString, InvestDataMetadata metadata)
        {
            var options = new DbContextOptionsBuilder<InvestData>()
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies()
                .UseModel(CreateModel(metadata))
                .Options;

            return new InvestData(options);
        }

        /// <summary>
        ///     Создает контекст инвест данных, настроенный под SQLite.
        /// </summary>
        public static InvestData ConfigureForSQLite(string connectionString, InvestDataMetadata metadata)
        {
            var options = new DbContextOptionsBuilder<InvestData>()
                .UseSqlite(connectionString)
                .UseLazyLoadingProxies()
                .UseModel(CreateModel(metadata))
                .Options;

            return new InvestData(options);
        }

        /// <summary>
        ///     Создает модель контекста инвест. данных.
        /// </summary>
        /// <param name="metadata">SQL-схема.</param>
        private static IModel CreateModel(InvestDataMetadata metadata)
        {
            // создаем конфигурации контекста данных
            var assetsConfig = new NetAssetValuesConfiguration(metadata[SqlTargetTable.Portfolio]);
            var flowsConfig = new FlowsConfiguration(metadata[SqlTargetTable.Flows]);
            var secsConfig = new SecuritiesConfiguration(metadata[SqlTargetTable.Securities]);
            var fixPreiodsConfig = new PriceFixationPeriodsConfiguration(metadata[SqlTargetTable.FixPeriods]);
            var reportsConfig = new ReportsConfiguration(metadata[SqlTargetTable.Reports]);

            // добавляем конфигурации к модели
            var modelBuilder = new ModelBuilder()
            .ApplyConfiguration(assetsConfig)
            .ApplyConfiguration(flowsConfig)
            .ApplyConfiguration(secsConfig)
            .ApplyConfiguration(fixPreiodsConfig)
            .ApplyConfiguration(reportsConfig);           

            // добавляем функции к модели
            modelBuilder.HasDbFunction(() => InvestDataExtensions.GetFlowDirection(default))
            .HasSchema("idep");

            // возвращаем модель
            return modelBuilder.FinalizeModel();
        }
    }    
}
