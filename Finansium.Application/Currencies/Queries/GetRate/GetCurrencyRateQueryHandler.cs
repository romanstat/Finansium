namespace Finansium.Application.Currencies.Queries.GetRate;

internal sealed class GetCurrencyRateQueryHandler
    : IQueryHandler<GetCurrencyRateQuery, decimal>
{
    public async Task<Result<decimal>> Handle(
        GetCurrencyRateQuery request,
        CancellationToken cancellationToken)
    {
        var fromCurrency = Currency.FromCode(request.FromCurrency);
        var toCurrency = Currency.FromCode(request.ToCurrency);

        Console.WriteLine(fromCurrency);
        Console.WriteLine(toCurrency);

        return await Task.FromResult(3.3M);
    }
}
