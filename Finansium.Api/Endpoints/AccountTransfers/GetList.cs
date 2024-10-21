using Finansium.Application.AccountTransfers.Queries.GetList;

namespace Finansium.Api.Endpoints.AccountTransfers;

internal sealed class GetList : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("account-transfers/list", async (ISender sender) =>
        {
            var result = await sender.Send(new GetAccountTransferListQuery());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.AccountTransfers);
    }
}
