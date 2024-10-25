using Finansium.Domain.Categories;
using Finansium.Domain.Counties;
using Finansium.Domain.News;
using Finansium.Domain.RecurringTransactions;
using Finansium.Domain.SavingsGoals;
using Finansium.Domain.Transactions;

namespace Finansium.Application.Abstractions.Data;

public interface IFinansiumDbContext
{
    DbSet<Account> Accounts { get; }

    DbSet<AccountTransfer> AccountTransfers { get; }

    DbSet<Category> Categories { get; }

    DbSet<Country> Countries { get; }

    DbSet<NewsItem> NewsItems { get; }

    DbSet<RecurringTransaction> RecurringTransactions { get; }

    DbSet<SavingsGoal> SavingsGoals { get; }

    DbSet<Transaction> Transactions { get; }

    DbSet<User> Users { get; }

    DbSet<Notification> Notifications {  get; }
}
