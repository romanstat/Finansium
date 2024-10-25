using Finansium.Domain.RecurringTransactions;

namespace Finansium.Application.RecurringTransactions.Commands.Create;

internal sealed class CreateRecurringTransactionCommandHandler(
    TimeProvider timeProvider,
    IAccountRepository accountRepository)
    : ICommandHandler<CreateRecurringTransactionCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        CreateRecurringTransactionCommand request, 
        CancellationToken cancellationToken)
    {
        var account = await accountRepository.GetByIdAsync(request.AccountId, cancellationToken);

        if (account is null)
        {
            return Result.Failure<Ulid>(AccountErrors.NotFound(request.AccountId));
        }

        var recurringTransaction = RecurringTransaction.Create(
            request.AccountId,
            new Money(request.Amount, account.Balance.Currency),
            TransactionType.FromName(request.Type),
            request.Interval,
            request.StartDate,
            request.EndDate,
            timeProvider.GetUtcNow(),
            request.Description);

        account.AddRange(recurringTransaction);

        return recurringTransaction.Id;
    }
}
