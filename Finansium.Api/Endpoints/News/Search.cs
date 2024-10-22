using Finansium.Application.News.Queries.Search;

namespace Finansium.Api.Endpoints.News;

internal sealed class Search : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("news/search/relevant", async (ISender sender) =>
        {
            var result = await sender.Send(new SearchNewsQuery());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.News);
    }
}
