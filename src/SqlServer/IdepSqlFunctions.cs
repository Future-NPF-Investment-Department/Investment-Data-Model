using InvestmentData.Classifications;
using InvestmentData.Context;

namespace InvestmentData.SqlServer
{
    /// <summary>
    ///     Defines SQL user-defined functions.
    /// </summary>
    public static class IdepSqlFunctions
    {
        /// <summary>
        ///     References GetFlowDirection SQL user-defined scalar-valued function.     
        /// </summary>
        /// <remarks>
        ///     For more details see <see cref="GetFlowDirection.sql"/> file in <see cref="InvestmentData.SqlServer"/> folder 
        ///     or navigate to Databases -> asrm_data -> Programmability -> Functions -> 
        ///     Scalar-valued Functions -> idep.GetFlowDirection in SQL Server Management Studio. 
        ///     <para>
        ///         <see cref="NotImplementedException"/> is thrown if method is used outside <see cref="src.Context.InvestmentDataContext"/> context.       
        ///     </para>
        /// </remarks>
        /// <exception cref="NotImplementedException"> 
        ///     is thrown if method is used outside <see cref="InvestmentDataContext"/> context.
        /// </exception>
        public static double GetFlowDirection(TransType TransitionType)
            => throw new NotImplementedException($"GetFlowDirection method could be used only within {nameof(InvestmentDataContext)} context.");
    }
}
