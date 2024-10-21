using Finansium.Domain.Accounts;
using Finansium.Domain.SavingsGoals;

namespace Finansium.Application.SavingsGoals.Commands.Create;

internal sealed class CreateSavingsGoalCommandHandler(
    IUserContext userContext,
    IAccountRepository accountRepository,
    ISavingsGoalRepository savingsGoalRepository)
    : ICommandHandler<CreateSavingsGoalCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        CreateSavingsGoalCommand request,
        CancellationToken cancellationToken)
    {
        if (!await savingsGoalRepository.IsNameUniqueAsync(
            userContext.UserId,
            request.Name,
            cancellationToken))
        {
            return Result.Failure<Ulid>(SavingsGoalErrors.UniqueName(request.Name));
        }

        var account = await accountRepository.GetByIdAsync(request.AccountId, cancellationToken);

        if (account is null)
        {
            return Result.Failure<Ulid>(AccountErrors.NotFound(request.AccountId));
        }

        var targetAmount = new Money(
            request.TargetAmount,
            account.Balance.Currency);

        var savingsGoal = SavingsGoal.Create(
            userContext.UserId,
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
