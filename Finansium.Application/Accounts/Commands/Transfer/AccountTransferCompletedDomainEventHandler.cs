using Finansium.Domain.Accounts.Events;
using Finansium.Domain.SavingsGoals;

namespace Finansium.Application.Accounts.Commands.Transfer;

internal sealed class AccountTransferCompletedDomainEventHandler(
    IAccountTransferRepository accountTransferRepository,
    ISavingsGoalRepository savingsGoalRepository)
    : INotificationHandler<AccountTransferCompletedDomainEvent>
{
    public async Task Handle(
        AccountTransferCompletedDomainEvent notification, 
        CancellationToken cancellationToken)
    {
        var accountTransfer = AccountTransfer.Create(
            notification.SourceAccountId,
            notification.TargetAccountId,
            notification.Amount,
            notification.CurrencyRate,
            notification.TransferDate);

        accountTransferRepository.Add(accountTransfer);

        await savingsGoalRepository.UpdateTargetAmountAsync(
            [notification.SourceAccountId, notification.TargetAccountId],
            cancellationToken);
    }
}
