using Finansium.Domain.Accounts;

namespace Finansium.Application.Accounts.Commands.Transfer;

internal sealed class TransferAccountCommandHandler(
    TimeProvider timeProvider,
    IAccountRepository accountRepository) : ICommandHandler<TransferAccountCommand>
{
    public async Task<Result> Handle(
        TransferAccountCommand request,
        CancellationToken cancellationToken)
    {
        var sourceAccount = await accountRepository.GetByIdAsync(request.SourceAccountId, cancellationToken);

        if (sourceAccount is null)
        {
            return Result.Failure(AccountErrors.NotFound(request.SourceAccountId));
        }

        var targetAccount = await accountRepository.GetByIdAsync(request.TargetAccountId, cancellationToken);

        if (targetAccount is null)
        {
            return Result.Failure(AccountErrors.NotFound(request.TargetAccountId));
        }

        var transferAmount = new Money(
            request.Amount,
            Currency.FromCode(sourceAccount.Balance.Currency.Code));

        var transferResult = sourceAccount.Transfer(
            targetAccount,
            transferAmount,
            request.CurrencyRate,
            timeProvider.GetUtcNow());

        return transferResult;
    }
}
