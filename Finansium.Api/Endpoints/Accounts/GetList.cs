using Finansium.Application.Accounts.Queries.GetList;

namespace Finansium.Api.Endpoints.Accounts;

internal sealed class GetList : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("accounts/list", async (ISender sender) =>
        {
            var result = await sender.Send(new GetAccountListQuery());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Accounts);
    }
}
