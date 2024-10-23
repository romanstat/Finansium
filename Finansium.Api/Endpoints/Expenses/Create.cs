using Finansium.Application.Expenses.Commands.Create;

namespace Finansium.Api.Endpoints.Expenses;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("expenses", async (CreateExpenseCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Expenses);
    }
}
