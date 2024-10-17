using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentDataModel.Model.Configurations
{
    /// <summary>
    ///     Configures <see cref="Security"/> entity for Entity Framework.
    /// </summary>
    public class SecuritiesConfiguration : IEntityTypeConfiguration<Security>
    {
        private readonly SqlTableMetadata _metadata;

        public SecuritiesConfiguration(SqlTableMetadata metadata)
        {
            _metadata = metadata;
        }

        public void Configure(EntityTypeBuilder<Security> builder)
        {
            // устанавливаем имя таблицы и схемы
            builder.ToTable(_metadata.TableName, _metadata.SchemaName);

            // устанавливаем ключ
            builder.HasKey(_metadata.KeyName);

            // устанавливаем мэппинг имен колонок
            foreach ((string prop, string col) in _metadata.Columns)
                builder.Property(prop).HasColumnName(col);

            // устанавливаем правила преобразования типов
            foreach (string prop in _metadata.Conversions)
                builder.Property(prop).HasConversion<string>();
        }
    }
}
