using Finansium.Application.Notifications.Commands.ChangeViewStatus;

namespace Finansium.Api.Endpoints.Notifications;

internal sealed class ChangeIsViwed : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("notifications/{id}/view-status", async (Ulid Id, ISender sender) =>
        {
            var result = await sender.Send(new ChangeViewStatusCommand(Id));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Notifications);
    }
}
