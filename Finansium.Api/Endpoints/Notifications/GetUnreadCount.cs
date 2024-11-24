using Finansium.Application.Notifications.Queries.GetUnreadCount;

namespace Finansium.Api.Endpoints.Notifications;

internal sealed class GetUnreadCount : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("notifications/unread-count", async (ISender sender) =>
        {
            var result = await sender.Send(new GetUnreadCountNotificationsQuery());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Notifications);
    }
}
