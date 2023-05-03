using InvestmentDataContext.Entities;
using Microsoft.EntityFrameworkCore;
using InvestmentDataContext.Classifications;

namespace InvestmentDataContext
{
    public class AssetsQueryBuilder : InvestmentDataQueryBuilder<AssetValue, AssetsQueryBuilder>
    {
        public AssetsQueryBuilder(InvestmentData context) : base(context)
            => _query = _context.Assets.AsNoTracking();

        private protected override AssetsQueryBuilder Builder
            => this;


        public AssetsQueryBuilder WithAccountingMethod(AccountingMethod? method)
        {
            _query = (method is not null)
                ? _query.Where(q => q.AccountingMethod == method)
                : _query;

            return this;
        }

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
