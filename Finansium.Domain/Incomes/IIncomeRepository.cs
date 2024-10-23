
namespace Finansium.Domain.Incomes;

public interface IIncomeRepository
{
    Task<Income?> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
    void Add(Income income);
    Task DeleteAsync(Ulid id, CancellationToken cancellationToken);
}
