using Finansium.Application.SavingsGoals.Commands.Delete;

namespace Finansium.Api.Endpoints.SavingsGoals;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("savings-goals/{id}", async (Ulid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteSavingsGoalCommand(id));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.SavingsGoals);
    }
}
