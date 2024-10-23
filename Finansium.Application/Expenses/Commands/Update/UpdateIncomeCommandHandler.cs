using Finansium.Domain.Accounts;
using Finansium.Domain.Categories;
using Finansium.Domain.Incomes;

namespace Finansium.Application.Incomes.Commands.Update;

internal sealed class UpdateExpenseCommandHandler(
    TimeProvider timeProvider,
    ICategoryRepository categoryRepository,
    IAccountRepository accountRepository,
    IIncomeRepository incomeRepository)
    : ICommandHandler<UpdateIncomeCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        UpdateIncomeCommand request, 
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

        var income = await incomeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (income is null)
        {
            return Result.Failure<Ulid>(IncomeErrors.NotFound(request.Id));
        }

        var amount = new Money(request.Amount, account.Balance.Currency);

        income.Update(
            request.CategoryId,
            request.AccountId,
            amount,
            timeProvider.GetUtcNow());

        return income.Id;
    }
}
