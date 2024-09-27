using Microsoft.EntityFrameworkCore;

namespace InvestmentDataModel
{
    public class FlowsQueryBuilder : InvestmentDataQueryBuilder<AssetFlow, FlowsQueryBuilder>
    {
        public FlowsQueryBuilder(InvestData context) : base(context)
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

        public FlowsQueryBuilder WithTransType(params TransType[]? transTypes)
        {
            _query = (transTypes is not null)
               ? _query.Where(q => transTypes.Contains(q.TransType))
               : _query;
            return this;
        }
    }
}
