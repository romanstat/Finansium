using Finansium.Application.Transactions.Commands.CreateExpense;

namespace Finansium.Api.Endpoints.Transactions;

internal sealed class CreateExpense : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("transactions/expense", async (CreateExpenseTransactionCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Transactions);
    }
}
