using Microsoft.EntityFrameworkCore;
using InvestmentDataModel.Classifications;
using InvestmentDataModel.Context;
using InvestmentDataModel.Context.Entities;

namespace InvestmentDataModel
{
    public class AssetsQueryBuilder : InvestmentDataQueryBuilder<AssetValue, AssetsQueryBuilder>
    {
        public AssetsQueryBuilder(InvestmentDataContext context) : base(context)
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
