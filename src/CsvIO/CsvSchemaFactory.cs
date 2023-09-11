#pragma warning disable IDE1006 // Naming styles

using CsvHelper.Configuration;
using InvestmentDataContext.Classifications;
using InvestmentDataContext.Entities;
using InvestmentDataContext.CsvIO.CsvSchemas;
using InvestmentDataContext.src.IO.CsvSchemas;

namespace InvestmentDataContext.CsvIO
{
    /// <summary>
    ///     Csv schema factory.
    /// </summary>
    public class CsvSchemaFactory
    {
        private readonly ReportSourceFile _report;
        private readonly Mapper _mapper;
        private const SqlTargetTable PORTF = SqlTargetTable.Portfolio;
        private const SqlTargetTable FLOWS = SqlTargetTable.Flows;
        private const string REGION = "REGION Trust";
        private const string RAIFF = "Raiffeisen Capital";
        private const string AFKSC = "AFK Systema Capital";

        public CsvSchemaFactory (ReportSourceFile report, Mapper mapper)
        {
            _report = report;
            _mapper = mapper;
        }

        /// <summary>
        ///     Report info used for csv-schema creating.
        /// </summary>
        public ReportSourceFile Report => _report;

        /// <summary>
        ///     Creates configured csv-schema depending on report info.
        /// </summary>
        /// <returns></returns>
        public ClassMap Create() => _report.Destination switch
        {
            PORTF => CreateCsvSchema<AssetValue>(),
            FLOWS => CreateCsvSchema<AssetFlow>(),
            _ => throw new NotImplementedException()
        };

        /// <summary>
        ///     Creates csv-schema for specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private ClassMap<T> CreateCsvSchema<T>()
            where T : InvestmentDataRecord
        {
            var schema = new CsvSchema<T>(_report, _mapper);
            ICsvSchemaConfigurer<T> configurer = _report.Destination switch
            {
                PORTF => (ICsvSchemaConfigurer<T>)CreatePortfoioCsvSchemaConfigurer(_report.Provider),
                FLOWS => (ICsvSchemaConfigurer<T>)CreateFlowsCsvSchemaConfigurer(_report.Provider),
                _ => throw new NotImplementedException()
            };
            schema.AcceptCsvSchemaConfigurer(configurer);
            return schema;
        }

        /// <summary>
        ///     Creates portfolio csv-schema configurer for specified provider.
        /// </summary>
        private static ICsvSchemaConfigurer<AssetValue> CreatePortfoioCsvSchemaConfigurer(string provider) => provider switch
        {
            REGION => new RegionPortfolioCsvSchemaConfigurer(),
            AFKSC => new AfkPortfolioCsvSchemaConfigurer(),
            RAIFF => new RaiffPortfolioCsvSchemaConfigurer(),
            _ => throw new Exception($"Provider '{provider}' unknown"),
        };

        /// <summary>
        ///     Creates flows csv-schema configurer for specified provider.
        /// </summary>
        private static ICsvSchemaConfigurer<AssetFlow> CreateFlowsCsvSchemaConfigurer(string provider) => provider switch
        {
            REGION => new RegionFlowsCsvSchemaConfigurer(),
            AFKSC => new AfkFlowsCsvSchemaConfigurer(),
            RAIFF => new RaiffFlowsCsvSchemaConfigurer(),
            _ => throw new Exception($"Provider '{provider}' unknown"),
        };
    }
}
