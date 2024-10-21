using Finansium.Application.Accounts.Commands.Delete;

namespace Finansium.Api.Endpoints.Accounts;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("accounts/{id}", async (Ulid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteAccountCommand(Id));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Accounts);
    }
}
