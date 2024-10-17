﻿using Microsoft.EntityFrameworkCore;

namespace InvestmentDataModel
{
    public abstract class InvestDataQueryBuilder<TData, TBuilder>
        where TData : InvestDataEntryBase
        where TBuilder : InvestDataQueryBuilder<TData, TBuilder>
    {
        private protected InvestData _context;
        private protected IQueryable<TData> _query = null!;

        private protected InvestDataQueryBuilder(InvestData context)
            => _context = context;

        private protected abstract TBuilder Builder { get; }

        public virtual TBuilder WithinDates(DateTime? start, DateTime? end)
        {
            if (start is not null && end is not null && start > end)
                throw new Exception("Filtration error: end date should be greater than start date");

            if (start is not null)
                _query = _query.Where(q => q.Date >= start);

            if (end is not null)
                _query = _query.Where(q => q.Date <= end);

            return Builder;
        }

        public virtual TBuilder WithAssetManagementCompany(string? amName)
        {
            _query = (amName is not null)
                ? _query.Where(q => q.AmName == amName)
                : _query;

            return Builder;
        }

        public virtual TBuilder WithFundName(string? fundName)
        {
            _query = (fundName is not null)
                ? _query.Where(q => q.FundName == fundName)
                : _query;

            return Builder;
        }

        public virtual TBuilder WithPensionPropertyType(PensionPropertyType? pptype)
        {
            _query = (pptype is not null)
                ? _query.Where(q => q.PensionProperty == pptype)
                : _query;

            return Builder;
        }

        public virtual TBuilder WithStrategy(string? strategy)
        {
            _query = (strategy is not null)
                ? _query.Where(q => q.StrategyName == strategy)
                : _query;

            return Builder;
        }

        public virtual TBuilder WithContract(string? contract)
        {
            _query = (contract is not null)
                ? _query.Where(q => EF.Functions.Like(q.Contract, contract))
                : _query;

            return Builder;
        }

        public virtual TBuilder WithIssuerName(string? name)
        {
            _query = (name is not null)
                ? _query.Where(q => EF.Functions.Like(q.EmitentName!, name))
                : _query;

            return Builder;
        }

        public virtual TBuilder WithIssuerId(string? issuerId)
        {
            _query = (issuerId is not null)
                ? _query.Where(q => q.Inn == issuerId)
                : _query;

            return Builder;
        }

        public virtual TBuilder WithIsins(params string[]? isins)
        {
            _query = (isins is not null)
                ? _query.Where(q => isins.Contains(q.Isin))
                : _query;

            return Builder;
        }

        public virtual TBuilder WithAssetClass(AssetClass? @class)
        {
            _query = (@class is not null)
                ? _query.Where(q => q.AssetClass == @class)
                : _query;

            return Builder;
        }

        public virtual TBuilder WithAssetType(AssetType? type)
        {
            _query = (type is not null)
                ? _query.Where(q => q.AssetType == type)
                : _query;

            return Builder;
        }

        public virtual TBuilder WithSecurityName(string? type)
        {
            _query = (type is not null)
                ? _query.Where(q => EF.Functions.Like(q.FullName!, type))
                : _query;

            return Builder;
        }

        public virtual TBuilder WithSecurityCurrency(string? currency)
        {
            _query = (currency is not null)
                ? _query.Where(q => q.Currency == currency)
                : _query;

            return Builder;
        }

        public virtual TBuilder WithRiskType(RiskType? risk)
        {
            _query = (risk is not null)
                ? _query.Where(q => q.RiskType == risk)
                : _query;

            return Builder;
        }

        public virtual TBuilder WithMaturityDate(DateTime? start, DateTime? end)
        {
            if (start is not null && end is not null && start > end)
                throw new Exception("Filtration error: end date should be greater than start date");

            if (start is not null)
                _query = _query.Where(q => q.MarketInfo.MaturityDate >= start);

            if (end is not null)
                _query = _query.Where(q => q.MarketInfo.MaturityDate <= end);

            return Builder;
        }

        public IQueryable<TData> GetQuery()
            => _query;

        public override string ToString()
            => _query.ToQueryString();
    }
}
