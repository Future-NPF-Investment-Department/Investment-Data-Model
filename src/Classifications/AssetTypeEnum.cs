
namespace InvestmentDataContext.Classifications
{
    /// <summary>
    ///     Represents asset type in portfolio. 
    /// </summary>
    public enum AssetType
    {
        None,               // не определено
        Equity,             // акции
        GovernmentBond,     // гос облигации
        CorporateBond,      // корп облигации
        SubfederalBond,     // субфедеральные облигации
        MutualFund,         // ЗПИФ, или любые другие своместные фонды (например ETF)
        Deposit,            // депозиты
        Repo,               // дебиторская задолженность по сделкам РЕПО (или просто сумма репо)
        Currency,           // валюта
        Cash,               // ДС на расчетных счетах
        Receivables,        // дебиторская задолженность
        Payables,           // кредиторская задолженность
        OtherAssets         // прочие активы
    }
}