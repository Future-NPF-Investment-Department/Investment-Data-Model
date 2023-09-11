using CsvHelper.Configuration;
using InvestmentDataContext.Entities;


namespace InvestmentDataContext.CsvIO.CsvSchemas
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
