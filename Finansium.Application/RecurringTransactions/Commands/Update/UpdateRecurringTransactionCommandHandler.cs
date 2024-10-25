using Finansium.Domain.RecurringTransactions;

namespace Finansium.Application.RecurringTransactions.Commands.Update;

internal sealed class UpdateRecurringTransactionCommandHandler(
    IAccountRepository accountRepository,
    IRecurringTransactionRepository recurringTransactionRepository,
    TimeProvider timeProvider)
    : ICommandHandler<UpdateRecurringTransactionCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        UpdateRecurringTransactionCommand request, 
        CancellationToken cancellationToken)
    {
        var account = await accountRepository.GetByIdAsync(request.AccountId, cancellationToken);

        if (account is null)
        {
            return Result.Failure<Ulid>(AccountErrors.NotFound(request.AccountId));
        }

        var recurringTransaction = await recurringTransactionRepository.GetByIdAsync(
            request.Id, 
            cancellationToken);

        if (recurringTransaction is null)
        {
            return Result.Failure<Ulid>(RecurringTransactionErrors.NotFound(request.AccountId));
        }

        recurringTransaction.Update(
            request.AccountId,
            new Money(request.Amount, account.Balance.Currency),
            TransactionType.FromName(request.Type),
            request.Interval,
            request.Description,
            request.StartDate,
            request.EndDate,
            timeProvider.GetUtcNow());

        return recurringTransaction.Id;
    }
}
