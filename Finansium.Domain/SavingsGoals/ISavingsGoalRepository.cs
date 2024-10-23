
namespace Finansium.Domain.SavingsGoals;

public interface ISavingsGoalRepository
{
    Task<SavingsGoal?> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
    Task<SavingsGoal?> GetByIdNoTrackingAsync(Ulid id, CancellationToken cancellationToken);
    Task<SavingsGoal?> GetByIdWithAccountAsync(Ulid id, CancellationToken cancellationToken);
    void Add(SavingsGoal savingsGoal);
    Task<bool> IsNameUniqueAsync(Ulid userId, string name, CancellationToken cancellationToken);
    Task DeleteAsync(Ulid id, CancellationToken cancellationToken);
    Task UpdateTargetAmountAsync(Ulid[] accountIds, CancellationToken cancellationToken);
}
