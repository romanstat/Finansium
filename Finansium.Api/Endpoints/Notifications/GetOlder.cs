using Finansium.Application.Notifications.Queries.GetOlder;

namespace Finansium.Api.Endpoints.Notifications;

internal sealed class GetOlder : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("notifications/older", async (ISender sender) =>
        {
            var result = await sender.Send(new GetOlderNotificationsQuery());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Notifications);
    }
}
