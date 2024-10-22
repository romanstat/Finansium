namespace Finansium.Application.Currencies.Queries.Search;

public sealed record SearchCurrencyQuery(string SearchTerm) : IQuery<IReadOnlyList<CurrencyResponse>>;
