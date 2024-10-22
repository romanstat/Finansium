using Finansium.Domain.Categories;

namespace Finansium.Persistence.Repositories;

internal sealed class CategoryRepository(FinansiumDbContext dbContext)
    : Repository<Category>(dbContext), ICategoryRepository
{
    public async Task<bool> IsNameUnique(string name, CategoryType type, CancellationToken cancellationToken) =>
        !await _dbSet.AnyAsync(category => 
            category.Name == name &&
            category.Type == type, 
            cancellationToken);
}
