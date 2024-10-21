namespace Finansium.Application.Accounts.Queries.GetList;

public sealed record AccountResponse(
    Ulid Id,
    string Name,
    decimal Amount,
    string Currency,
    string Status);
