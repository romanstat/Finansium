
namespace Finansium.Domain.Categories;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
    Task<Category?> GetByIdWithBudgetsAsync(Ulid id, CancellationToken cancellationToken);
    void Add(Category category);
    Task DeleteAsync(Ulid id, CancellationToken cancellationToken);
    Task<bool> IsNameUnique(Ulid Id, string name, TransactionType transactionType, CancellationToken cancellationToken);
}
