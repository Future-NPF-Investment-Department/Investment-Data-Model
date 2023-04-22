namespace InvestmentDataContext
{
    public class InvestmentDataQuery
    {
        public static AssetsQueryBuilder NewAssetsQuery(InvestmentData context)
             => new AssetsQueryBuilder(context);

        public static FlowsQueryBuilder NewFlowsQuery(InvestmentData context)
             => new FlowsQueryBuilder(context);
    }
}
