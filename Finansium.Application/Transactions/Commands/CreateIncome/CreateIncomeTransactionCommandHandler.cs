using Finansium.Domain.Categories;
using Finansium.Domain.Transactions;

namespace Finansium.Application.Transactions.Commands.CreateIncome;

internal sealed class CreateIncomeTransactionCommandHandler(
    ICategoryRepository categoryRepository,
    IAccountRepository accountRepository)
    : ICommandHandler<CreateIncomeTransactionCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        CreateIncomeTransactionCommand request,
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

        var amount = new Money(request.Amount, account.Balance.Currency);

        var transaction = Transaction.Create(
            request.AccountId,
            TransactionType.Income,
            amount,
            request.Date,
            request.Description);

        account.AddTransactions(transaction);

        return transaction.Id;
    }
}
