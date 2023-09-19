
namespace InvestmentData.Classifications
{
    /// <summary>
    ///     Represents type of transaction. Used in FlowInfo entity.
    /// </summary>
    public enum TransType
    {
        None,                   // не определено
        CashInflow,             // поступления ДС
        CashOutflow,            // вывод ДС
        InternalCashFlow,       // внутренние переводы (? не уверен)
        SecuritiesArrival,      // поступление ценных бумаг в портфель
        SecuritiesWithdrawal,   // выбытие ценных бумаг из портфеля
        SecuritiesPurchase,     // покупка ценных бумаг
        SecuritiesSale,         // продажа ценных бумаг
        CurrencyPurchase,       // покупка валюты
        CurrencySale,           // продажа валюты
        Dividends,              // выплата дивидендов
        CouponPayment,          // выплата купона по облигациям
        NominalPayment,         // выплата номинала облигации
        RepoPurchase,           // заключение сделки РЕПО | 1-я часть сделки РЕПО | покупка РЕПО
        RepoSale,               // завершение сделки РЕПО | 2-я часть сделки РЕПО | продажа РЕПО
        MPBOpen,                // открытие МНО
        MPBClosure,             // закрытие МНО
        DepositOpen,            // открытие депозита
        DepositClosure,         // закрытие депозита
        InterestPayment,        // выплата процентов по депозиту или МНО
        AMServices,             // плата за услуги УК
        SDServices,             // плата за услуги НСД
        OtherCosts,             // прочие списания, рахсоды
        OtherCashInflow,        // прочие денежные поступления
        OtherCashOutflow        // прочие денежные выводы
    }
}
