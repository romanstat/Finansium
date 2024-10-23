
namespace Finansium.Domain.Incomes;

public interface IIncomeRepository
{
    Task<Income?> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
    Task DeleteAsync(Ulid id, CancellationToken cancellationToken);
}
