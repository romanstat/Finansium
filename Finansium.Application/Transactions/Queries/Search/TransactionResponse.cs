namespace Finansium.Application.Transactions.Queries.Search;

public sealed record TransactionResponse(
    Ulid Id,
    string CategoryName,
    string AccountName,
    decimal Amount,
    Currency Currency,
    DateTimeOffset Date,
    string? Description);
