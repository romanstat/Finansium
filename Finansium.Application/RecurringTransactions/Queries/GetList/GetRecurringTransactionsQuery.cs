namespace Finansium.Application.RecurringTransactions.Queries.GetList;

public sealed record GetRecurringTransactionsQuery(string Type) 
    : IQuery<IReadOnlyList<RecurringTransactionResponse>>;
