/* ================================================================================================================================
 Represents pricing type for an asset in portfolio. Could be fixed and non-fixed. Fixed is used for AssetInfo during price fixation 
 preiods. Non-fixed pricing is considered to be default value when there is no price fixation in period.
 
 e.g. the period from February to October 2022 was notable for price fixing in the securities market, and during such a period 
 fund was receiving 2 portfolio reports for the same report date. The first one contained data in real prices (fixed pricing) and 
 the second one contained data in fair prices (non-fixed pricing). 
=================================================================================================================================== */

namespace InvestmentDataContext.Classifications
{
    /// <summary>
    ///     Represents pricing type for an asset in portfolio. 
    /// </summary>
    public enum PricingType
    {
        NonFixed,
        Fixed
    }
}
