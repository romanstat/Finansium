using Finansium.Application.Notifications.Queries.GetToday;

namespace Finansium.Application.Notifications.Queries.GetOlder;

internal sealed class GetOlderNotificationsQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext finansiumDbContext,
    TimeProvider timeProvider)
    : IQueryHandler<GetOlderNotificationsQuery, IReadOnlyList<NotififcationResponse>>
{
    public async Task<Result<IReadOnlyList<NotififcationResponse>>> Handle(
        GetOlderNotificationsQuery request,
        CancellationToken cancellationToken)
    {
        var userNotifications = await finansiumDbContext.Notifications
            .Where(notification =>
                notification.UserId == userContext.UserId &&
                notification.CreatedAt.Date < timeProvider.GetUtcNow().Date)
            .Select(notification => new NotififcationResponse(
                notification.Id,
                notification.Title,
                notification.Description,
                notification.CreatedAt,
                notification.IsViewed))
            .ToListAsync(cancellationToken);

        return userNotifications;
    }
}
