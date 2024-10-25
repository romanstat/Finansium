

namespace Finansium.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
    Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<User?> GetByUsernameNoTrackingAsync(string username, CancellationToken cancellationToken);
    void Add(User user);
    Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken);
    Task<bool> IsUsernameUniqueAsync(string username, CancellationToken cancellationToken);
    Task<bool> IsPasswordValidAsync(string username, string password, CancellationToken cancellation);
}
