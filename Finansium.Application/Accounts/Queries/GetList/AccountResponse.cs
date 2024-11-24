namespace Finansium.Application.Accounts.Queries.GetList;

public sealed record AccountResponse(
    Ulid Id,
    string Name,
    decimal Balance,
    string Currency,
    DateTimeOffset CreatedAt,
    DateTimeOffset ModifiedAt);
