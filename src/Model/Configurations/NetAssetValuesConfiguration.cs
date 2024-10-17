using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentDataModel.Model.Configurations
{
    /// <summary>
    ///     Configures <see cref="NetAssetValue"/> entity for Entity Framework.
    /// </summary>
    public class NetAssetValuesConfiguration : IEntityTypeConfiguration<NetAssetValue>
    {
        private readonly SqlTableMetadata _metadata;

        public NetAssetValuesConfiguration(SqlTableMetadata metadata) 
        {
            _metadata = metadata;
        }

        public void Configure(EntityTypeBuilder<NetAssetValue> builder)
        {
            // устанавливаем имя таблицы и схемы
            builder.ToTable(_metadata.TableName, _metadata.SchemaName);

            // устанавливаем ключ
            builder.HasKey(_metadata.KeyName);

            // устанавливаем мэппинг имен колонок
            foreach ((string prop, string col) in _metadata.Columns)
                builder.Property(prop).HasColumnName(col);

            // устанавлиаем игнорируемые свойства
            foreach (string prop in _metadata.Ignored)
                builder.Ignore(prop);

            // устанавливаем правила преобразования типов
            foreach (string prop in _metadata.Conversions)
                builder.Property(prop).HasConversion<string>();

            // устанавоиваем внешние ключи
            builder.HasOne(ai => ai.MarketInfo)
            .WithMany(si => si.Portfolio)
            .HasForeignKey(ai => ai.Isin)
            .HasPrincipalKey(si => si.Isin);

            builder.HasOne(av => av.Report)
            .WithMany(src => src.AssetRecords)
            .HasForeignKey(av => av.ReportName)
            .HasPrincipalKey(src => src.FileName);
        }
    }
}
