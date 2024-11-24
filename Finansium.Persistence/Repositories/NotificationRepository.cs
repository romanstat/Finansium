using Finansium.Domain.Users;

namespace Finansium.Persistence.Repositories;

internal sealed class NotificationRepository(FinansiumDbContext dbContext)
    : Repository<Notification>(dbContext), INotificationRepository
{
    public async Task ViewedAllAsync(
        Ulid userId,
        CancellationToken cancellationToken)
    {
        await _dbSet
            .Where(x => x.UserId == userId)
            .ExecuteUpdateAsync(notification =>
                notification.SetProperty(p => p.IsViewed, p => true), 
                cancellationToken);
    }
}
