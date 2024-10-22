using Finansium.Application.Currencies.Queries.GetRate;

namespace Finansium.Api.Endpoints.Currencies;

internal sealed class GetRate : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("currencies/{fromCurrency}/{toCurrency}", async (
            string fromCurrency, 
            string toCurrency, 
            ISender sender) =>
        {
            var result = await sender.Send(new GetCurrencyRateQuery(fromCurrency, toCurrency));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .AllowAnonymous()
            .WithTags(Tags.Currencies);
    }
}

