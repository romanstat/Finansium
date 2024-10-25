﻿using Finansium.Domain.Categories;

namespace Finansium.Persistence.Repositories;

internal sealed class CategoryRepository(FinansiumDbContext dbContext)
    : Repository<Category>(dbContext), ICategoryRepository
{
    public async Task<Category?> GetByIdWithBudgetsAsync(Ulid id, CancellationToken cancellationToken) =>
        await _dbSet
            .Include(category => category.Budgets)
            .SingleOrDefaultAsync(category => category.Id == id, cancellationToken);

    public async Task<bool> IsNameUnique(string name, TransactionType transactionType, CancellationToken cancellationToken) =>
        !await _dbSet.AnyAsync(category => 
            category.Name == name &&
            category.TransactionType == transactionType, 
            cancellationToken);
}
