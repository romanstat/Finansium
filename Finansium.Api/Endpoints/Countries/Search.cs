using Finansium.Application.Countries.Queries;

namespace Finansium.Api.Endpoints.Countries;

internal sealed class Search : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("countries/search", async (SearchCountryQuery query, ISender sender) =>
        {
            var result = await sender.Send(query);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .AllowAnonymous()
            .WithTags(Tags.Countries);
    }
}
