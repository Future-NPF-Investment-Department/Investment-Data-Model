using InvestmentDataContext.Classifications;
using InvestmentDataContext.Entities;
using InvestmentDataContext;
using Microsoft.EntityFrameworkCore;

namespace InvestmentDataContext
{
    public class FlowsQueryBuilder : InvestmentDataQueryBuilder<AssetFlow, FlowsQueryBuilder>
    {
        public FlowsQueryBuilder(InvestmentData context) : base(context)
            => _query = _context.Flows.AsNoTracking();

        private protected override FlowsQueryBuilder Builder
            => this;

        public FlowsQueryBuilder WithFlowId(long? id)
        {
            _query = _query.Where(q => q.Id == id);
            return this;
        }

        public virtual FlowsQueryBuilder WithOpearationDate(DateTime? start, DateTime? end)
        {
            if (start is not null && end is not null && start > end)
                throw new Exception("Filtration error: end date should be greater than start date");

            if (start is not null)
                _query = _query.Where(q => q.OperationDate >= start);

            if (end is not null)
                _query = _query.Where(q => q.OperationDate <= end);

            return this;
        }

        public FlowsQueryBuilder WithTransType(TransType? transType)
        {
            _query = (transType is not null)
               ? _query.Where(q => q.TransType == transType)
               : _query;
            return this;
        }
    }
}
