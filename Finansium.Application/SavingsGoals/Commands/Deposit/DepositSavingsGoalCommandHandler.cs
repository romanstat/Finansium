using Finansium.Domain.Accounts;
using Finansium.Domain.SavingsGoals;

namespace Finansium.Application.SavingsGoals.Commands.Deposit;

internal sealed class DepositSavingsGoalCommandHandler(
    TimeProvider timeProvider,
    IAccountRepository accountRepository,
    ISavingsGoalRepository savingsGoalRepository)
    : ICommandHandler<DepositSavingsGoalCommand>
{
    public async Task<Result> Handle(
        DepositSavingsGoalCommand request, 
        CancellationToken cancellationToken)
    {
        var fromAccount = await accountRepository.GetByIdAsync(request.FromAccountId, cancellationToken);

        if (fromAccount is null)
        {
            return Result.Failure<Ulid>(AccountErrors.NotFound(request.FromAccountId));
        }

        var savingsGoal = await savingsGoalRepository.GetByIdWithAccountAsync(request.Id, cancellationToken);

        if (savingsGoal is null)
        {
            return Result.Failure<Ulid>(SavingsGoalErrors.NotFound(request.Id));
        }

        fromAccount.Transfer(
            savingsGoal.Account!, 
            new Money(request.Amount, fromAccount.Balance.Currency), 
            request.CurrencyRate, 
            timeProvider.GetUtcNow());

        savingsGoal.UpdateStatus(savingsGoal.Account!.Balance);

        return Result.Success();
    }
}
