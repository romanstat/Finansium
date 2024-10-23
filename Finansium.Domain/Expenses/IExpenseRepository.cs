
namespace Finansium.Domain.Expenses;

public interface IExpenseRepository
{
    Task<Expense?> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
    Task DeleteAsync(Ulid id, CancellationToken cancellationToken);
}
