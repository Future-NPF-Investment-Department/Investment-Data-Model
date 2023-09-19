using CsvHelper.Configuration;
using InvestmentData.Context.Entities;

namespace InvestmentData.CsvIO.CsvSchemas
{

    public class CsvSchema<T> : ClassMap<T> 
        where T : InvestmentDataRecord
    {
        public CsvSchema(ReportSourceFile report, Mapper mapper)
        {
            Report = report;
            Mapper = mapper;
        }

        public ReportSourceFile Report { get; }
        public Mapper Mapper { get; }

        public void AcceptCsvSchemaConfigurer(ICsvSchemaConfigurer<T> provider)        
            => provider.ConfigureCsvChema(this);        
    }




    
}
