using Finansium.Domain.Accounts;
using Finansium.Domain.Categories;
using Finansium.Domain.Counties;
using Finansium.Domain.Expenses;
using Finansium.Domain.Incomes;
using Finansium.Domain.News;
using Finansium.Domain.SavingsGoals;

namespace Finansium.Application.Abstractions.Data;

public interface IFinansiumDbContext
{
    DbSet<Account> Accounts { get; }

    DbSet<AccountTransfer> AccountTransfers { get; }

    DbSet<Category> Categories { get; }

    DbSet<Country> Countries { get; }

    DbSet<Expense> Expenses { get; }

    DbSet<Income> Incomes { get; }

    DbSet<NewsItem> NewsItems { get; }

    DbSet<Notification> Notifications {  get; }

    DbSet<SavingsGoal> SavingsGoals { get; }

    DbSet<User> Users { get; }
}
