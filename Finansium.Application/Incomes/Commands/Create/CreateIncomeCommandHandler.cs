using Finansium.Domain.Accounts;
using Finansium.Domain.Categories;
using Finansium.Domain.Incomes;

namespace Finansium.Application.Incomes.Commands.Create;

internal sealed class CreateIncomeCommandHandler(
    ICategoryRepository categoryRepository,
    IAccountRepository accountRepository)
    : ICommandHandler<CreateIncomeCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        CreateIncomeCommand request,
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

        var income = Income.Create(
            request.AccountId,
            amount,
            request.Date);

        account.AddIncomes(income);

        return income.Id;
    }
}
