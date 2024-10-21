using Finansium.Application.SavingsGoals.Commands.Deposit;

namespace Finansium.Api.Endpoints.SavingsGoals;

internal sealed class Deposit : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("savings-goals/deposit", async (DepositSavingsGoalCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.SavingsGoals);
    }
}
