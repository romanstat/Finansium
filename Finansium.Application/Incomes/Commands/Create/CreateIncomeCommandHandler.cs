using Finansium.Domain.Accounts;
using Finansium.Domain.Categories;
using Finansium.Domain.Incomes;

namespace Finansium.Application.Incomes.Commands.Create;

internal sealed class CreateIncomeCommandHandler(
    TimeProvider timeProvider,
    IUserContext userContext,
    ICategoryRepository categoryRepository,
    IAccountRepository accountRepository,
    IIncomeRepository incomeRepository)
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
            userContext.UserId,
            request.CategoryId,
            request.AccountId,
            amount,
            timeProvider.GetUtcNow());

        incomeRepository.Add(income);

        return income.Id;
    }
}
