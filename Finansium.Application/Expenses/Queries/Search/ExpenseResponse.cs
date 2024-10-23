namespace Finansium.Application.Expenses.Queries.Search;

public sealed record ExpenseResponse(
    Ulid Id,
    string CategoryName,
    string AccountName,
    decimal Amount,
    Currency Currency,
    string Description,
    DateTimeOffset Date);
