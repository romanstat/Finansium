using Finansium.Domain.Budgets;

namespace Finansium.Persistence.Repositories;

internal sealed class BudgetRepository(FinansiumDbContext dbContext)
    : Repository<Budget>(dbContext), IBudgetRepository
{
}
