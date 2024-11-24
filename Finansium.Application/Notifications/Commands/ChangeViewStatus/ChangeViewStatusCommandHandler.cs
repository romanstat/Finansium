namespace Finansium.Application.Notifications.Commands.ChangeViewStatus;

internal sealed class ChangeViewStatusCommandHandler(
    INotificationRepository notificationService)
    : ICommandHandler<ChangeViewStatusCommand>
{
    public async Task<Result> Handle(
        ChangeViewStatusCommand request, 
        CancellationToken cancellationToken)
    {
        var notification = await notificationService.GetByIdAsync(
            request.Id, 
            cancellationToken);

        if (notification is null)
        {
            return Result.Failure(NotificationErrors.NotFound(request.Id));
        }

        notification.Viewed(!notification.IsViewed);

        return Result.Success();
    }
}
