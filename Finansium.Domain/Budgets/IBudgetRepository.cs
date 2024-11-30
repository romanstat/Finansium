

namespace Finansium.Domain.Budgets;

public interface IBudgetRepository
{
    Task<List<Budget>> GetByIdsAsync(IEnumerable<Ulid> ids, CancellationToken cancellationToken);
    Task DeleteAsync(Ulid id, CancellationToken cancellationToken);
}
