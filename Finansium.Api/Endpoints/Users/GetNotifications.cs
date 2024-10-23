using Finansium.Application.Users.Queries.GetNotifications;

namespace Finansium.Api.Endpoints.Users;

internal sealed class GetNotifications : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/notifications", async (ISender sender) =>
        {
            var result = await sender.Send(new GetUserNotificationsQuery());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Users);
    }
}
