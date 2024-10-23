using Finansium.Application.Categories.Queries.Search;

namespace Finansium.Api.Endpoints.Categories;

internal sealed class Search : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("categories/search", async (SearchCategoryQuery query, ISender sender) =>
        {
            var result = await sender.Send(query);
 
            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Categories);
    }
}
