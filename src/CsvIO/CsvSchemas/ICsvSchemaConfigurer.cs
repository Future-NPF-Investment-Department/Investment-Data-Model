using InvestmentData.Context.Entities;

namespace InvestmentData.CsvIO.CsvSchemas
{
    public interface ICsvSchemaConfigurer<T>
        where T : InvestmentDataRecord
    {
        public void ConfigureCsvChema(CsvSchema<T> csvSchema);            
    }
}
