using InvestmentDataContext.Entities;
using InvestmentDataContext.CsvIO.CsvSchemas;

namespace InvestmentDataContext.CsvIO.CsvSchemas
{
    public interface ICsvSchemaConfigurer<T>
        where T : InvestmentDataRecord
    {
        public void ConfigureCsvChema(CsvSchema<T> csvSchema);            
    }
}
