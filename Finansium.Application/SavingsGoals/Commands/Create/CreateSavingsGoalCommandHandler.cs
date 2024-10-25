using Finansium.Domain.SavingsGoals;

namespace Finansium.Application.SavingsGoals.Commands.Create;

internal sealed class CreateSavingsGoalCommandHandler(
    IAccountRepository accountRepository,
    ISavingsGoalRepository savingsGoalRepository)
    : ICommandHandler<CreateSavingsGoalCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        CreateSavingsGoalCommand request,
        CancellationToken cancellationToken)
    {
        var account = await accountRepository.GetByIdAsync(request.AccountId, cancellationToken);

        if (account is null)
        {
            return Result.Failure<Ulid>(AccountErrors.NotFound(request.AccountId));
        }

        if (!await savingsGoalRepository.IsNameUniqueAsync(
            account.Id,
            request.Name,
            cancellationToken))
        {
            return Result.Failure<Ulid>(SavingsGoalErrors.UniqueName(request.Name));
        }

        var targetAmount = new Money(
            request.TargetAmount,
            account.Balance.Currency);

        var savingsGoal = SavingsGoal.Create(
            request.AccountId,
            request.Name,
            targetAmount,
            request.Note,
            request.StartDate,
            request.EndDate);

        savingsGoalRepository.Add(savingsGoal);

        savingsGoal.UpdateStatus(account.Balance);

        return savingsGoal.Id;
    }
}
