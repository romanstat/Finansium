using Finansium.Application.RecurringTransactions.Commands.Update;

namespace Finansium.Api.Endpoints.RecurringTransactions;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("recurring-transactions", async (UpdateRecurringTransactionCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.RecurringTransactions);
    }
}
