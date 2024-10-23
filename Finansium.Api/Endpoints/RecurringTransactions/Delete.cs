using Finansium.Application.RecurringTransactions.Commands.Delete;

namespace Finansium.Api.Endpoints.RecurringTransactions;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("recurring-transactions/{id}", async (Ulid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteRecurringTransactionCommand(id));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.RecurringTransactions);
    }
}
