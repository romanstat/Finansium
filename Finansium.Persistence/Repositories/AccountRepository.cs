using Finansium.Domain.Accounts;

namespace Finansium.Persistence.Repositories;

internal sealed class AccountRepository(FinansiumDbContext dbContext)
    : Repository<Account>(dbContext), IAccountRepository
{
    public async Task<bool> IsExistsAsync(Ulid userId, string name, CancellationToken cancellationToken) =>
        await _dbSet.AnyAsync(account => account.UserId == userId && account.Name == name, cancellationToken);

    public async Task<List<Account>> GetByUserIdAsync(Ulid userId, CancellationToken cancellationToken) =>
        await _dbSet.Where(account => account.UserId == userId).ToListAsync(cancellationToken);
}
