using Finansium.Domain.Accounts;
using Finansium.Domain.Categories;
using Finansium.Domain.Expenses;

namespace Finansium.Application.Incomes.Commands.Create;

internal sealed class CreateExpenseCommandHandler(
    TimeProvider timeProvider,
    IUserContext userContext,
    ICategoryRepository categoryRepository,
    IAccountRepository accountRepository,
    IExpenseRepository expenseRepository)
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
            userContext.UserId,
            request.CategoryId,
            request.AccountId,
            amount,
            request.Description,
            timeProvider.GetUtcNow());

        expenseRepository.Add(expense);

        return expense.Id;
    }
}
