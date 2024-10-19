using Finansium.Application.Users.Commands.Register;

namespace Finansium.Api.Endpoints.Users;

internal sealed class Register : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/register", async (RegisterUserCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .AllowAnonymous()
            .WithTags(Tags.Users);
    }
}
