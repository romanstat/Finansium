using Finansium.Domain.SavingsGoals;
using Finansium.Domain.SavingsGoals.Events;

namespace Finansium.Application.SavingsGoals.Commands.Events;

internal sealed class SavingsGoalCompletedDomainEventHandler(
    TimeProvider timeProvider,
    ISavingsGoalRepository savingsGoalRepository,
    IUserRepository userRepository)
    : INotificationHandler<SavingsGoalCompletedDomainEvent>
{
    public async Task Handle(
        SavingsGoalCompletedDomainEvent notification,
        CancellationToken cancellationToken)
    {
        var savingsGoal = await savingsGoalRepository.GetByIdWithAccountNoTrackingAsync(
            notification.Id,
            cancellationToken);

        if (savingsGoal is null)
        {
            return;
        }

        var user = await userRepository.GetByIdAsync(
            savingsGoal.Account!.UserId,
            cancellationToken);

        if (user is null)
        {
            return;
        }

        var userNotification = Notification.Create(
            "Цель достигнута",
            $"Поздравляем! {savingsGoal.Name} цель завершилась",
            timeProvider.GetUtcNow());

        user.AddNotifications(userNotification);
    }
}
