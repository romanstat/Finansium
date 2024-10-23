using Finansium.Application.Incomes.Queries.Search;

namespace Finansium.Api.Endpoints.Incomes;

internal sealed class Search : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("incomes/search", async (ISender sender) =>
        {
            var result = await sender.Send(new SearchIncomeQuery());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Incomes);
    }
}
