using Finansium.Application.RecurringTransactions.Commands.Create;

namespace Finansium.Api.Endpoints.RecurringTransactions;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("recurring-transactions", async (CreateRecurringTransactionCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.RecurringTransactions);
    }
}
