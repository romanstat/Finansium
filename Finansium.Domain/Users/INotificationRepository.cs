
namespace Finansium.Domain.Users;

public interface INotificationRepository
{
    Task<Notification?> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
    Task ViewedAllAsync(Ulid userId, CancellationToken cancellationToken);
}
