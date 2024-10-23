
namespace Finansium.Domain.Expenses;

public interface IExpenseRepository
{
    void Add(Expense expense);
    Task DeleteAsync(Ulid id, CancellationToken cancellationToken);
}
