namespace Finansium.Application.Notifications.Queries.GetToday;

internal sealed class GetTodayNotificationsQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext finansiumDbContext,
    TimeProvider timeProvider)
    : IQueryHandler<GetTodayNotificationsQuery, IReadOnlyList<NotififcationResponse>>
{
    public async Task<Result<IReadOnlyList<NotififcationResponse>>> Handle(
        GetTodayNotificationsQuery request,
        CancellationToken cancellationToken)
    {
        var userNotifications = await finansiumDbContext.Notifications
            .Where(notification =>
                notification.UserId == userContext.UserId &&
                notification.CreatedAt.Date == timeProvider.GetUtcNow().Date)
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
