using Finansium.Application.SavingsGoals.Commands.Update;

namespace Finansium.Api.Endpoints.SavingsGoals;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("savings-goals", async (UpdateSavingsGoalCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.SavingsGoals);
    }
}
