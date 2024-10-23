using Finansium.Domain.Incomes;

namespace Finansium.Persistence.Repositories;

internal sealed class IncomeRepository(FinansiumDbContext dbContext)
    : Repository<Income>(dbContext), IIncomeRepository
{
}
