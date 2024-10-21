using Finansium.Application.Accounts.Commands.Update;

namespace Finansium.Api.Endpoints.Accounts;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("accounts", async (UpdateAccountCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Accounts);
    }
}
