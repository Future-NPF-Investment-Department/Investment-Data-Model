
namespace InvestmentDataModel
{
    public static class InvestDataExtensions
    {
        public static TEnum ToEnum<TEnum>(this string input) where TEnum : Enum
        {
            if (Enum.IsDefined(typeof(TEnum), input))
                return (TEnum)Enum.Parse(typeof(TEnum), input);
            return (TEnum)Enum.ToObject(typeof(TEnum), 0);
        }

        /// <summary>
        ///     References GetFlowDirection SQL user-defined scalar-valued function.     
        /// </summary>
        /// <remarks>
        ///     For more details see <see cref="GetFlowDirection.sql"/> file in <see cref="InvestmentDataModel.SqlServer"/> folder 
        ///     or navigate to Databases -> asrm_data -> Programmability -> Functions -> 
        ///     Scalar-valued Functions -> idep.GetFlowDirection in SQL Server Management Studio. 
        ///     <para>
        ///         <see cref="NotImplementedException"/> is thrown if method is used outside <see cref="src.InvestData"/> context.       
        ///     </para>
        /// </remarks>
        /// <exception cref="NotImplementedException"> 
        ///     is thrown if method is used outside <see cref="InvestData"/> context.
        /// </exception>
        public static double GetFlowDirection(TransType TransitionType)
            => throw new NotImplementedException($"GetFlowDirection method could be used only within {nameof(InvestData)} context.");
    }
}
