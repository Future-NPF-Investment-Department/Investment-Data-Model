using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentDataModel.Model.Configurations
{
    /// <summary>
    ///     Configures <see cref="PriceFixationEntry"/> entity for Entity Framework.
    /// </summary>
    public class PriceFixationConfigurer : IEntityTypeConfiguration<PriceFixationEntry>
    {
        public void Configure(EntityTypeBuilder<PriceFixationEntry> builder)
        {
            builder.ToTable("PriceFixations", "idep");
            builder.HasKey(pfi => new { pfi.FundName, pfi.FixationDate });
        }
    }
}
