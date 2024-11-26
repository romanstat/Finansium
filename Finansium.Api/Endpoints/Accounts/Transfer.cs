using Finansium.Application.Accounts.Commands.Transfer;

namespace Finansium.Api.Endpoints.Accounts;

internal sealed class Transfer : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("accounts/transfer", async (TransferAccountCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Accounts);
    }
}

