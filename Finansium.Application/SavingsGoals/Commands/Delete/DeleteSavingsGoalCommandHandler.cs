using Finansium.Domain.SavingsGoals;

namespace Finansium.Application.SavingsGoals.Commands.Delete;

internal sealed class DeleteSavingsGoalCommandHandler(ISavingsGoalRepository savingsGoalRepository)
    : ICommandHandler<DeleteSavingsGoalCommand>
{
    public async Task<Result> Handle(
        DeleteSavingsGoalCommand request,
        CancellationToken cancellationToken)
    {
        await savingsGoalRepository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
