using Finansium.Domain.RecurringTransactions;

namespace Finansium.Persistence.Repositories;

internal sealed class RecurringTransactionRepository(FinansiumDbContext dbContext)
    : Repository<RecurringTransaction>(dbContext), IRecurringTransactionRepository
{
}
