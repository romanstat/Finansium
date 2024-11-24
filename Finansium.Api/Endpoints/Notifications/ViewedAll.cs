using Finansium.Application.Notifications.Commands.ViewedAll;

namespace Finansium.Api.Endpoints.Notifications;

internal sealed class ViewedAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("notifications/viewed-all", async (ISender sender) =>
        {
            var result = await sender.Send(new ViewedAllNotificationsCommand());

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Notifications);
    }
}
