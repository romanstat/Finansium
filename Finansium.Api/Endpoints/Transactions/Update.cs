using Finansium.Application.Transactions.Commands.Update;

namespace Finansium.Api.Endpoints.Transactions;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("transactions", async (UpdateTransactionCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Transactions);
    }
}
