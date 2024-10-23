
namespace Finansium.Application.Users.Queries.GetNotifications;

internal sealed class GetUserNotificationsQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext finansiumDbContext)
    : IQueryHandler<GetUserNotificationsQuery, IReadOnlyList<NotififcationResponse>>
{
    public async Task<Result<IReadOnlyList<NotififcationResponse>>> Handle(
        GetUserNotificationsQuery request,
        CancellationToken cancellationToken)
    {
        var userNotifications = await finansiumDbContext.Notifications
            .Where(notification => notification.Id == userContext.UserId)
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
