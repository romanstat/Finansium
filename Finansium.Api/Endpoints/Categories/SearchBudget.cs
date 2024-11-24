using Finansium.Application.Categories.Queries.SearchBudget;

namespace Finansium.Api.Endpoints.Categories;

internal sealed class SearchBudget : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("categories/expense/budgets/search", async (SearchBudgetQuery query, ISender sender) =>
        {
            var result = await sender.Send(query);
 
            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Categories);
    }
}
