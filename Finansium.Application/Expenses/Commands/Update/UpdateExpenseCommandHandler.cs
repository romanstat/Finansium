using Finansium.Domain.Accounts;
using Finansium.Domain.Categories;
using Finansium.Domain.Expenses;

namespace Finansium.Application.Expenses.Commands.Update;

internal sealed class UpdateExpenseCommandHandler(
    ICategoryRepository categoryRepository,
    IAccountRepository accountRepository,
    IExpenseRepository expenseRepository)
    : ICommandHandler<UpdateExpenseCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        UpdateExpenseCommand request,
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

        var expense = await expenseRepository.GetByIdAsync(request.Id, cancellationToken);

        if (expense is null)
        {
            return Result.Failure<Ulid>(ExpenseErrors.NotFound(request.Id));
        }

        var amount = new Money(request.Amount, account.Balance.Currency);

        expense.Update(
            request.CategoryId,
            request.AccountId,
            amount,
            request.Date);

        return expense.Id;
    }
}
