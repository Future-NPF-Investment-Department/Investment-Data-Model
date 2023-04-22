using InvestmentDataContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentDataContext
{
    public class AssetsQueryBuilder : InvestmentDataQueryBuilder<AssetValue, AssetsQueryBuilder>
    {
        public AssetsQueryBuilder(InvestmentData context) : base(context)
            => _query = _context.Assets.AsNoTracking();

        private protected override AssetsQueryBuilder Builder
            => this;

        public AssetsQueryBuilder WithRealPrices()
        {
            _query = _query.Where(q => q.Pricing.UseRealPricing);
            return this;
        }

        public AssetsQueryBuilder WithFairPrices()
        {
            _query = _query.Where(q => q.Pricing.UseFairPricing);
            return this;
        }
    }
}
