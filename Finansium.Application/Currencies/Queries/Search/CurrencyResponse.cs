namespace Finansium.Application.Currencies.Queries.Search;

public sealed record CurrencyResponse(
    string Abbreviation,
    string Name,
    string Sign);
