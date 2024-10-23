using Finansium.Domain.Expenses;

namespace Finansium.Persistence.Repositories;

internal sealed class ExpenseRepository(FinansiumDbContext dbContext)
    : Repository<Expense>(dbContext), IExpenseRepository
{
}
