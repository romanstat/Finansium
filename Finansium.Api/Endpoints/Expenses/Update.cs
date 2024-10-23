using Finansium.Application.Expenses.Commands.Update;

namespace Finansium.Api.Endpoints.Expenses;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("expenses", async (UpdateExpenseCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Expenses);
    }
}
