namespace InvestmentDataContext
{
    public static class IdepDataExtensions
    {
        public static TEnum ToEnum<TEnum>(this string input) where TEnum : Enum
        {
            if (Enum.IsDefined(typeof(TEnum), input)) 
                return (TEnum)Enum.Parse(typeof(TEnum), input);
            return (TEnum)Enum.ToObject(typeof(TEnum), 0);
        }
    }
}
