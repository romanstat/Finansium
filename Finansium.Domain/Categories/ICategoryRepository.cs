
namespace Finansium.Domain.Categories;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
    void Add(Category category);
    Task DeleteAsync(Ulid id, CancellationToken cancellationToken);
    Task<bool> IsNameUnique(string name, TransactionType transactionType, CancellationToken cancellationToken);
}
