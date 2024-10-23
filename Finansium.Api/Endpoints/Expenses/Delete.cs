using Finansium.Application.Expenses.Commands.Delete;

namespace Finansium.Api.Endpoints.Expenses;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("expenses", async (DeleteExpenseCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Expenses);
    }
}
