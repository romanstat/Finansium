namespace Finansium.Application.Incomes.Queries.Search;

public sealed record IncomeResponse(
    Ulid Id,
    string CategoryName,
    string AccountName,
    decimal Amount,
    Currency Currency,
    DateTimeOffset Date);
