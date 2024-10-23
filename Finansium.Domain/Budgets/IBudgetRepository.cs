
namespace Finansium.Domain.Budgets;

public interface IBudgetRepository
{
    Task DeleteAsync(Ulid id, CancellationToken cancellationToken);
}
