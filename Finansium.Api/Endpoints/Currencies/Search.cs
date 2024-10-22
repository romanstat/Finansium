using Finansium.Application.Currencies.Queries.Search;

namespace Finansium.Api.Endpoints.Currencies;

internal sealed class Search : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("currencies/search", async (SearchCurrencyQuery query, ISender sender) =>
        {
            var result = await sender.Send(query);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .AllowAnonymous()
            .WithTags(Tags.Currencies);
    }
}
