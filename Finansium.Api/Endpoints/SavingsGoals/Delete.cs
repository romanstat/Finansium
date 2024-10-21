using Finansium.Application.SavingsGoals.Commands.Delete;

namespace Finansium.Api.Endpoints.SavingsGoals;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("savings-goals/{id}", async (Ulid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteSavingsGoalCommand(Id));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.SavingsGoals);
    }
}
