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
        var user = await userRepository.GetByIdAsync(
            notification.UserId,
            cancellationToken);

        if (user is null)
        {
            return;
        }

        var savingsGoal = await savingsGoalRepository.GetByIdNoTrackingAsync(
            notification.SavingsGoalId,
            cancellationToken);

        if (savingsGoal is null)
        {
            return;
        }

        var userNotification = Notification.Create(
            notification.UserId,
            "Цель достигнута",
            $"Поздравляем! {savingsGoal.Name} цель завершилась",
            timeProvider.GetUtcNow());

        user.AddNotifications(userNotification);
    }
}
