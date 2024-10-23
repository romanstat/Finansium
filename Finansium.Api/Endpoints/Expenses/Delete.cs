using Finansium.Application.Expenses.Commands.Delete;

namespace Finansium.Api.Endpoints.Expenses;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("expenses/{id}", async (Ulid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteExpenseCommand(id));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Expenses);
    }
}
