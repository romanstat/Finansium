namespace Finansium.Application.Countries.Queries;

public sealed record SearchCountryQuery(string SearchTerm) : IQuery<IReadOnlyList<CountryResponse>>;
