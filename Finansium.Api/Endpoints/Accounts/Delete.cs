using Finansium.Application.Accounts.Commands.Delete;

namespace Finansium.Api.Endpoints.Accounts;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("accounts/{id}", async (Ulid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteAccountCommand(id));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Accounts);
    }
}
