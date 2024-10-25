namespace Finansium.Application.Transactions.Queries.Search;

public sealed record SearchTransactionQuery(string Type) : IQuery<IReadOnlyList<TransactionResponse>>;
