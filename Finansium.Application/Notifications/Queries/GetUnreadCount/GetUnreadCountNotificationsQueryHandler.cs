namespace Finansium.Application.Notifications.Queries.GetUnreadCount;

internal sealed class GetUnreadCountNotificationsQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext finansiumDbContext)
    : IQueryHandler<GetUnreadCountNotificationsQuery, int>
{
    public async Task<Result<int>> Handle(
        GetUnreadCountNotificationsQuery request,
        CancellationToken cancellationToken)
{
    var unreadNotifications = await finansiumDbContext.Notifications
        .Where(notification =>
            notification.UserId == userContext.UserId &&
            !notification.IsViewed)
        .CountAsync(cancellationToken);

    return unreadNotifications;
}
}
