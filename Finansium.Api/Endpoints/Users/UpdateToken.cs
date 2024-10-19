using Finansium.Application.Users.Commands.UpdateToken;

namespace Finansium.Api.Endpoints.Users;

internal sealed class UpdateToken : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("users/tokens", async (ISender sender) =>
        {
            var result = await sender.Send(new UpdateUserTokenCommand());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .AllowAnonymous()
            .WithTags(Tags.Users);
    }
}
