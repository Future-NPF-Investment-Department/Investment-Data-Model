using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentDataModel.Model.Configurations
{
    /// <summary>
    ///     Configures <see cref="PriceFixationPeriod"/> entity for Entity Framework.
    /// </summary>
    public class PriceFixationPeriodsConfiguration : IEntityTypeConfiguration<PriceFixationPeriod>
    {
        private readonly SqlTableMetadata _metadata;

        public PriceFixationPeriodsConfiguration(SqlTableMetadata metadata)
        {
            _metadata = metadata;
        }

        public void Configure(EntityTypeBuilder<PriceFixationPeriod> builder)
        {
            // устанавливаем имя таблицы и схемы
            builder.ToTable(_metadata.TableName, _metadata.SchemaName);

            // устанавливаем ключ
            builder.HasKey(pfi => new { pfi.FundName, pfi.FixationDate });

            // устанавливаем мэппинг имен колонок
            foreach ((string prop, string col) in _metadata.Columns)
                builder.Property(prop).HasColumnName(col);
        }
    }
}
