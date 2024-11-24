using Finansium.Application.Notifications.Queries.GetToday;

namespace Finansium.Api.Endpoints.Notifications;

internal sealed class GetToday : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("notifications/today", async (ISender sender) =>
        {
            var result = await sender.Send(new GetTodayNotificationsQuery());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Notifications);
    }
}
