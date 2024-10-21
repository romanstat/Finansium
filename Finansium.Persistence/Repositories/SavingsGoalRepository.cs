using Finansium.Domain.SavingsGoals;

namespace Finansium.Persistence.Repositories;

internal sealed class SavingsGoalRepository(FinansiumDbContext dbContext)
    : Repository<SavingsGoal>(dbContext), ISavingsGoalRepository
{
    public async Task<SavingsGoal?> GetByIdWithAccountAsync(Ulid id, CancellationToken cancellationToken) =>
        await _dbSet
        .Include(savingsGoal => savingsGoal.Account)
        .SingleOrDefaultAsync(
            savingsGoal => savingsGoal.Id == id,
            cancellationToken);

    public async Task<bool> IsNameUniqueAsync(Ulid userId, string name, CancellationToken cancellationToken) =>
        !await _dbSet.AnyAsync(savingsGoal =>
            savingsGoal.UserId ==  userId &&
            savingsGoal.Name == name,
            cancellationToken);

    public async Task UpdateTargetAmountAsync(Ulid[] accountIds, CancellationToken cancellationToken) =>
        await _dbSet
        .Where(savingsGoal =>
            accountIds.Contains(savingsGoal.AccountId) && 
            savingsGoal.Account!.Balance >= savingsGoal.TargetAmount)
        .ExecuteUpdateAsync(
            savingsGoal => savingsGoal.SetProperty(p => p.IsCompleted, true), 
            cancellationToken);
}
