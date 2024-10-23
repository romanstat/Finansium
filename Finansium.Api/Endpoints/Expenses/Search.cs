using Finansium.Application.Expenses.Queries.Search;

namespace Finansium.Api.Endpoints.Expenses;

internal sealed class Search : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("expenses/search", async (ISender sender) =>
        {
            var result = await sender.Send(new SearchExpenseQuery());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Expenses);
    }
}
