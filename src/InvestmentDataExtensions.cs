using System.Globalization;
using CsvHelper.Configuration;
using InvestmentData.Classifications;

namespace InvestmentData
{
    public static class InvestmentDataExtensions
    {
        public static TEnum ToEnum<TEnum>(this string input) where TEnum : Enum
        {
            if (Enum.IsDefined(typeof(TEnum), input)) 
                return (TEnum)Enum.Parse(typeof(TEnum), input);
            return (TEnum)Enum.ToObject(typeof(TEnum), 0);
        }

        public static MemberMap<TClass, string> RemoveQuotes<TClass>(this MemberMap<TClass, string> memberMap)
        {
            if (memberMap.Data.Names.Count is 0)
                throw new Exception("Csv field names are not provided.");

            return memberMap.Convert(args =>
            {
                string? val = string.Empty;
                string headers = string.Empty;
                foreach (var field in memberMap.Data.Names)
                {
                    headers = headers + "; " + field;
                    args.Row.TryGetField(field, out string? value);
                    val = value;
                    if (value is not null)
                        return value.Contains('"') ? value.Replace("\"", "") : value;
                }
                throw new Exception($"Cannot get value ({val}) from csv fields: ({headers})");
            });
        }

        public static MemberMap<TClass, TMember> PremapWithDict<TClass, TMember>(this MemberMap<TClass, TMember> memberMap, Dictionary<string, TMember> mapper, bool caseSensitive = false)
        {
            if (memberMap.Data.Names.Count is 0)
                throw new Exception("Csv field names are not provided.");

            return memberMap.Convert(args =>
            {
                foreach (var field in memberMap.Data.Names)
                {
                    args.Row.TryGetField(field, out string? value);
                    if (value is not null)
                    {
                        if (caseSensitive is false) value = value.ToLower();
                        return mapper[value];
                    }
                }
                throw new Exception("Cannot get value from csv field");
            });            
        }


        public static MemberMap<TClass, RiskType> CheckRiskIsin<TClass>(this MemberMap<TClass, RiskType> memberMap, Dictionary<string, RiskType> mapper)
        {
            if (memberMap.Data.Names.Count is 0)
                throw new Exception("Csv field names are not provided.");

            return memberMap.Convert(args =>
            {
                foreach (var field in memberMap.Data.Names)
                {
                    args.Row.TryGetField(field, out string? value);
                    if (value is not null)
                        return mapper.ContainsKey(value) 
                        ? RiskType.Risk 
                        : RiskType.NonRisk;                    
                }
                throw new Exception("Cannot get value from csv field");
            });
        }


        public static MemberMap<TClass, TMember> UseCulture<TClass, TMember>(this MemberMap<TClass, TMember> memberMap, string cultureName)
        {
            var culture = CultureInfo.GetCultureInfo(cultureName);
            memberMap.TypeConverterOption.CultureInfo(culture);
            return memberMap;
        }



        public static MemberMap<TClass, double?> UniversalSeparatorDouble<TClass>(this MemberMap<TClass, double?> memberMap)
        {
            if (memberMap.Data.Names.Count is 0)
                throw new Exception("Csv field names are not provided.");

            return memberMap.Convert(args =>
            {
                foreach (var field in memberMap.Data.Names)
                { 
                    args.Row.TryGetField(memberMap.Data.Names[0], out double? dval);
                    if (dval is not null) 
                        return dval.Value;

                    args.Row.TryGetField(memberMap.Data.Names[0], out string? sval);
                    if (sval is not null && sval.Contains('.'))
                    {
                        sval = sval.Replace('.', ',');
                        return double.Parse(sval);
                    }
                }


                throw new Exception("pizdec");

            });                
        }
    }
}
