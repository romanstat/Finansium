namespace Finansium.Domain.Accounts;

public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
    void Add(Account account);
    Task<bool> IsExistsAsync(Ulid userId, string name, CancellationToken cancellationToken);
    Task DeleteAsync(Ulid id, CancellationToken cancellationToken);
    Task<List<Account>> GetByUserIdAsync(Ulid userId, CancellationToken cancellationToken);
}
