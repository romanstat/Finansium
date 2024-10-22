namespace Finansium.Application.Currencies.Queries.GetRate;

public sealed record GetCurrencyRateQuery(
    string FromCurrency, 
    string ToCurrency) : IQuery<decimal>;
