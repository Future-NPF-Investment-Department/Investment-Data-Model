namespace InvestmentDataContext.Classifications
{   
    /// <summary>
    ///     Represents asset class.
    /// </summary>
    public enum AssetClass
    {
        None,           // не определено
        Equities,       // акции
        Bonds,          // облигации
        Repo,           // сделки репо
        Deposits,       // депозиты
        Cash,           // ДС
        Currency,       // валюта
        MutualFunds,    // совместные фонды (ЗПИФ, ОПИФ, ETF и пр.)
        OtherAssets     // прочие активы
    }
}
