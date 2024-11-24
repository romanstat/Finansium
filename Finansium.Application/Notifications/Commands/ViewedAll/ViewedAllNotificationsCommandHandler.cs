namespace Finansium.Application.Notifications.Commands.ViewedAll;

internal sealed class ViewedAllNotificationsCommandHandler(
    IUserContext userContext,
    INotificationRepository notificationRepository)
    : ICommandHandler<ViewedAllNotificationsCommand>
{
    public async Task<Result> Handle(
        ViewedAllNotificationsCommand request, 
        CancellationToken cancellationToken)
    {
        await notificationRepository.ViewedAllAsync(
            userContext.UserId, 
            cancellationToken);

        return Result.Success();
    }
}
