
namespace Finansium.Domain.RecurringTransactions;

public interface IRecurringTransactionRepository
{
    Task<RecurringTransaction?> GetByIdAsync(Ulid accountId, CancellationToken cancellationToken);
    Task DeleteAsync(Ulid id, CancellationToken cancellationToken);
}
