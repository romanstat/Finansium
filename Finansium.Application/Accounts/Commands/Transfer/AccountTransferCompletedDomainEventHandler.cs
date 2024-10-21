using Finansium.Domain.Accounts;
using Finansium.Domain.Accounts.Events;

namespace Finansium.Application.Accounts.Commands.Transfer;

internal sealed class AccountTransferCompletedDomainEventHandler(IAccountTransferRepository accountTransferRepository)
    : INotificationHandler<AccountTransferCompletedDomainEvent>
{
    public Task Handle(
        AccountTransferCompletedDomainEvent notification, 
        CancellationToken cancellationToken)
    {
        var accountTransfer = AccountTransfer.Create(
            notification.UserId,
            notification.SourceAccountId,
            notification.TargetAccountId,
            notification.Amount,
            notification.CurrencyRate,
            notification.TransferDate);

        accountTransferRepository.Add(accountTransfer);

        return Task.CompletedTask;
    }
}
