using Finansium.Application.Users.Commands.Login;

namespace Finansium.Api.Endpoints.Users;

internal sealed class Login : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/login", async (LoginUserCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .AllowAnonymous()
            .WithTags(Tags.Users);
    }
}
