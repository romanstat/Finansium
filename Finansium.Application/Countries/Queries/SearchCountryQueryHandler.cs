namespace Finansium.Application.Countries.Queries;

internal sealed class SearchCountryQueryHandler(
    IFinansiumDbContext dbContext,
    IQueryService queryService)
    : IQueryHandler<SearchCountryQuery, IReadOnlyList<CountryResponse>>
{
    public async Task<Result<IReadOnlyList<CountryResponse>>> Handle(
        SearchCountryQuery request,
        CancellationToken cancellationToken)
    {
        var countriesQuery = dbContext.Countries.AsQueryable();

        countriesQuery = queryService.SearchByDefault(countriesQuery, request.SearchTerm);

        var countries = await countriesQuery
            .Select(country => new CountryResponse(
                country.Id,
                country.ShortName,
                country.FullName,
                country.Alpha2Code,
                country.Alpha3Code,
                country.NumericCode))
            .ToListAsync(cancellationToken);

        return countries;
    }
}
