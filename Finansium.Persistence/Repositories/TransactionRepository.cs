using Finansium.Domain.Transactions;

namespace Finansium.Persistence.Repositories;

internal sealed class TransactionRepository(FinansiumDbContext dbContext)
    : Repository<Transaction>(dbContext), ITransactionRepository
{
}
