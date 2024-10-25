namespace Finansium.Application.RecurringTransactions.Queries.Search;

public sealed record SearchRecurringTransactionsQuery(string Type)
    : IQuery<IReadOnlyList<RecurringTransactionResponse>>;
