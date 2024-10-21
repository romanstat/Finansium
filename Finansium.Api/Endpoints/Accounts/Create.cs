using Finansium.Application.Accounts.Commands.Create;

namespace Finansium.Api.Endpoints.Accounts;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("accounts", async (CreateAccountCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Accounts);
    }
}
