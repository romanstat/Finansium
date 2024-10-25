namespace Finansium.Domain.Transactions;

public interface ITransactionRepository
{
    Task<Transaction?> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
    Task DeleteAsync(Ulid id, CancellationToken cancellationToken);
}
