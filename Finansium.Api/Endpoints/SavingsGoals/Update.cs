using Finansium.Application.SavingsGoals.Commands.Create;

namespace Finansium.Api.Endpoints.SavingsGoals;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("savings-goals", async (CreateSavingsGoalCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.SavingsGoals);
    }
}
