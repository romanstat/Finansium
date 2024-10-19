using Finansium.Application.Users.Commands.UpdatePassword;

namespace Finansium.Api.Endpoints.Users;

internal sealed class UpdatePassword : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("users/change-password", async (UpdateUserPasswordCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(() => Results.Ok(), ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Users);
    }
}
