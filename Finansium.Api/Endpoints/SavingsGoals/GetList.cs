using Finansium.Application.SavingsGoals.Queries.GetList;

namespace Finansium.Api.Endpoints.SavingsGoals;

internal sealed class GetList : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("savings-goals/list", async (ISender sender) =>
        {
            var result = await sender.Send(new GetSavingsGoalListQuery());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.SavingsGoals);
    }
}
