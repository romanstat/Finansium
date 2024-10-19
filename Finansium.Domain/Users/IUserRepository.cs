
namespace Finansium.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<User?> GetByUsernameNoTrackingAsync(string username, CancellationToken cancellationToken);
    Task<User?> GetByUsernameAndPasswordNoTrackingAsync(string username, string password, CancellationToken cancellationToken);
    void Add(User user);
    Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken);
}
