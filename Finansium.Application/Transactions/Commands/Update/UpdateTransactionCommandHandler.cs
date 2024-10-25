using Finansium.Domain.Categories;
using Finansium.Domain.Transactions;

namespace Finansium.Application.Transactions.Commands.Update;

internal sealed class UpdateTransactionCommandHandler(
    ICategoryRepository categoryRepository,
    IAccountRepository accountRepository,
    ITransactionRepository transactionRepository)
    : ICommandHandler<UpdateTransactionCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        UpdateTransactionCommand request,
        CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            return Result.Failure<Ulid>(CategoryErrors.NotFound(request.CategoryId));
        }

        var account = await accountRepository.GetByIdAsync(request.AccountId, cancellationToken);

        if (account is null)
        {
            return Result.Failure<Ulid>(AccountErrors.NotFound(request.AccountId));
        }

        var transaction = await transactionRepository.GetByIdAsync(request.Id, cancellationToken);

        if (transaction is null)
        {
            return Result.Failure<Ulid>(TransactionErrors.NotFound(request.Id));
        }

        var amount = new Money(request.Amount, account.Balance.Currency);

        transaction.Update(
            request.CategoryId,
            request.AccountId,
            amount,
            request.Date);

        return transaction.Id;
    }
}
