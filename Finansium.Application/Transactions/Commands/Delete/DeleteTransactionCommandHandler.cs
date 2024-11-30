using Finansium.Domain.Transactions;

namespace Finansium.Application.Transactions.Commands.Delete;

internal sealed class DeleteTransactionCommandHandler(
    ITransactionRepository transactionRepository,
    IAccountRepository accountRepository)
    : ICommandHandler<DeleteTransactionCommand>
{
    public async Task<Result> Handle(
        DeleteTransactionCommand request,
        CancellationToken cancellationToken)
    {
        var transaction = await transactionRepository.GetByIdAsync(request.Id, cancellationToken);

        if (transaction is null)
        {
            return Result.Failure<Ulid>(TransactionErrors.NotFound(request.Id));
        }

        var account = await accountRepository.GetByIdAsync(transaction.AccountId, cancellationToken);

        if (account is null)
        {
            return Result.Failure<Ulid>(AccountErrors.NotFound(transaction.AccountId));
        }

        if (transaction.Type == TransactionType.Income)
        {
            account.Credit(transaction.Amount);
        }
        else
        {
            account.Debit(transaction.Amount);
        }

        await transactionRepository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
