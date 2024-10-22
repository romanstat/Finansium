namespace Finansium.Application.Currencies.Queries.Search;

internal sealed class SearchCurrencyQueryHandler
    : IQueryHandler<SearchCurrencyQuery, IReadOnlyList<CurrencyResponse>>
{
    public async Task<Result<IReadOnlyList<CurrencyResponse>>> Handle(
        SearchCurrencyQuery request, 
        CancellationToken cancellationToken)
    {
        var currencies = Currency.All
            .Where(currency => 
                request.SearchTerm.IsEmpty() || 
                currency.Code.ContainsIgnoreCase(request.SearchTerm) ||
                currency.Name.ContainsIgnoreCase(request.SearchTerm))
            .Select(currency => new CurrencyResponse(
                currency.Code,
                currency.Name,
                currency.Sign))
            .ToList();

        return await Task.FromResult(currencies);
    }
}
