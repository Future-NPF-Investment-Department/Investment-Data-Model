using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentDataModel.Model.Configurations
{
    /// <summary>
    ///     Configures <see cref="PriceFixationPeriod"/> entity for Entity Framework.
    /// </summary>
    public class PriceFixationPeriodEntityConfigurer : IEntityTypeConfiguration<PriceFixationPeriod>
    {
        public void Configure(EntityTypeBuilder<PriceFixationPeriod> builder)
        {
            builder.ToTable("PriceFixations", "idep");
            builder.HasKey(pfi => new { pfi.FundName, pfi.FixationDate });
        }
    }
}
