using Finansium.Domain.Accounts;
using Finansium.Domain.Counties;
using Finansium.Domain.SavingsGoals;

namespace Finansium.Application.Abstractions.Data;

public interface IFinansiumDbContext
{
    DbSet<Account> Accounts { get; }

    DbSet<AccountTransfer> AccountTransfers { get; }

    DbSet<Country> Countries { get; }

    DbSet<SavingsGoal> SavingsGoals { get; }

    DbSet<User> Users { get; }
}
