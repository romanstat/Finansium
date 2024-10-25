using Finansium.Application.Transactions.Commands.Delete;

namespace Finansium.Api.Endpoints.Transactions;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("transactions/{id}", async (Ulid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteTransactionCommand(id));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Transactions);
    }
}
