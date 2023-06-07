using InvestmentDataContext.Entities;

namespace InvestmentDataContext.CsvInterop
{

    public interface IReportSourceFileVisitor
    {
        /// <summary>
        ///     Configures csv schema for report source file.
        /// </summary>
        /// <param name="report"></param>
        public void ConfigureReportCsvSchema(ReportSourceFile report);
    }
}
