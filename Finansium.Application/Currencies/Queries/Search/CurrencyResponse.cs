namespace Finansium.Application.Currencies.Queries.Search;

public sealed record CurrencyResponse(
    string Code,
    string Name,
    string Sign);
