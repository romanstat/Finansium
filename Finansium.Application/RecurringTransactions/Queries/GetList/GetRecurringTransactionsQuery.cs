namespace Finansium.Application.RecurringTransactions.Queries.GetList;

public sealed record GetRecurringTransactionsQuery : IQuery<IReadOnlyList<RecurringTransactionResponse>>;
