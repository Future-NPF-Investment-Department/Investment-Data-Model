using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentDataModel.Context
{
    /// <summary>
    ///     Configures <see cref="PriceFixationInfo"/> entity for Entity Framework.
    /// </summary>
    public class PriceFixationConfigurer : IEntityTypeConfiguration<PriceFixationInfo>
    {
        public void Configure(EntityTypeBuilder<PriceFixationInfo> builder)
        {
            builder.ToTable("PriceFixations", "idep");
            builder.HasKey(pfi => new { pfi.FundName, pfi.FixationDate });
        }
    }
}
