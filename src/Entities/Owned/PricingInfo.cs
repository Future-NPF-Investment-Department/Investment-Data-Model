using InvestmentDataContext.Classifications;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InvestmentDataContext.Entities.Owned
{
    /// <summary>
    ///     Asset pricing information.
    /// </summary>
    /// <remarks>
    ///     This type is owned by <see cref="AssetValue"/> entity type.
    /// </remarks>
    public record PricingInfo
    {
        /// <summary>
        ///     Asset pricing type.
        /// </summary>
        public PriceFixationKind PriceFixation { get; set; }
        /// <summary>
        ///     Boolean flag to select all assets that priced at real prices.
        /// </summary>
        public bool UseRealPricing { get; set; }
        /// <summary>
        ///     Boolean flag to select all assets that priced at fair prices.
        /// </summary>
        public bool UseFairPricing { get; set; }
        
        /// <summary>
        ///     Defines Report specific <see cref="PricingInfo"/>.
        /// </summary>
        /// <param name="report">target report information.</param>
        /// <param name="priceFixationPeriods">price fixation periods.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static PricingInfo DefineReportPricing(ReportSourceFile report, IEnumerable<PriceFixationInfo> priceFixationPeriods)
        {
            PricingInfo pi = new();

            foreach (var period in priceFixationPeriods)
            {
                if (report.ReportDate is null || period.ContainsDate(report.ReportDate.Value) is false) continue;

                if (report.PricingType is ReportPricingType.RealPrices)
                {
                    pi.PriceFixation = PriceFixationKind.Fixed;
                    pi.UseRealPricing = true;
                    pi.UseFairPricing = false;
                }
                else if (report.PricingType is ReportPricingType.FairPrices)
                {
                    pi.PriceFixation = PriceFixationKind.NonFixed;
                    pi.UseRealPricing = false;
                    pi.UseFairPricing = true;
                }
            }

            if (report.PricingType is ReportPricingType.FairPrices)
            {
                int index = report.FullPath.IndexOf(report.FileName);
                string folderPath = report.FullPath.Remove(index, report.FileName.Length);
                string message = $"Cannot define pricing parameters for report '{report.FileName}'.\n" +
                    $"Report is considered to contain fair priced data however report date {report.ReportDate} is not associated with any known price fixation period.\n" +
                    $"Check your price fixation periods or report location: {folderPath} should contain only fair priced reports.";
                throw new Exception(message);
            }

            pi.PriceFixation = PriceFixationKind.NonFixed;
            pi.UseRealPricing = true;
            pi.UseFairPricing = true;

            return pi;
        }
    }
}
