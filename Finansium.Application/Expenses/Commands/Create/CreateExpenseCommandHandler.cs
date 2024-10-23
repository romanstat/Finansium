using Finansium.Domain.Accounts;
using Finansium.Domain.Categories;
using Finansium.Domain.Expenses;

namespace Finansium.Application.Expenses.Commands.Create;

internal sealed class CreateExpenseCommandHandler(
    ICategoryRepository categoryRepository,
    IAccountRepository accountRepository)
    : ICommandHandler<CreateExpenseCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        CreateExpenseCommand request,
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

        var expense = Expense.Create(
            request.CategoryId,
            amount,
            request.Description,
            request.Date);

        account.AddExpenses(expense);

        return expense.Id;
    }
}
