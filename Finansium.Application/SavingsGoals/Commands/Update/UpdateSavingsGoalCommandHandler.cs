using Finansium.Domain.SavingsGoals;

namespace Finansium.Application.SavingsGoals.Commands.Update;

internal sealed class UpdateSavingsGoalCommandHandler(
    TimeProvider timeProvider,
    ISavingsGoalRepository savingsGoalRepository,
    IAccountRepository accountRepository)
    : ICommandHandler<UpdateSavingsGoalCommand>
{
    public async Task<Result> Handle(
        UpdateSavingsGoalCommand request,
        CancellationToken cancellationToken)
    {
        var savingsGoal = await savingsGoalRepository.GetByIdAsync(request.Id, cancellationToken);

        if (savingsGoal == null)
        {
            return Result.Failure(SavingsGoalErrors.NotFound(request.Id));
        }

        var account = await accountRepository.GetByIdAsync(savingsGoal.AccountId, cancellationToken);

        if (account is null)
        {
            return Result.Failure(AccountErrors.NotFound(savingsGoal.AccountId));
        }

        var targetAmount = new Money(
            request.TargetAmount,
            account.Balance.Currency);

        savingsGoal.Update(request.Name, targetAmount);

        savingsGoal.UpdateStatus(account.Balance, timeProvider.GetUtcNow());

        return Result.Success();
    }
}
