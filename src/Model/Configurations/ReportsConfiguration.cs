using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentDataModel.Model.Configurations
{
    /// <summary>
    ///     Configures <see cref="SourceFile"/> entity for Entity Framework.
    /// </summary>
    public class ReportsConfiguration : IEntityTypeConfiguration<SourceFile>
    {
        private readonly SqlTableMetadata _metadata;

        public ReportsConfiguration(SqlTableMetadata metadata)
        {
            _metadata = metadata;
        }

        public void Configure(EntityTypeBuilder<SourceFile> builder)
        {
            // устанавливаем имя таблицы и схемы
            builder.ToTable(_metadata.TableName, _metadata.SchemaName);

            // устанавливаем ключ
            builder.HasKey(_metadata.KeyName);
            builder.HasAlternateKey(rep => rep.FileName);

            // устанавливаем мэппинг имен колонок
            foreach ((string prop, string col) in _metadata.Columns)
                builder.Property(prop).HasColumnName(col);

            // устанавливаем правила преобразования типов
            foreach (string prop in _metadata.Conversions)
                builder.Property(prop).HasConversion<string>();
        }
    }
}
