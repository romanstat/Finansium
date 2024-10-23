using Finansium.Domain.Accounts.Events;
using Finansium.Domain.Expenses;
using Finansium.Domain.Incomes;
using Finansium.Domain.RecurringTransactions;
using Finansium.Domain.SavingsGoals;

namespace Finansium.Domain.Accounts;

/// <summary>
/// Счета пользователя
/// </summary>
public sealed class Account : Entity
{
    private readonly List<SavingsGoal> _savingsGoals = [];
    private readonly List<Expense> _expenses = [];
    private readonly List<Income> _incomes = [];
    private readonly List<RecurringTransaction> _recurringTransactions = [];

    public Ulid UserId { get; private set; }

    public User User { get; private set; }

    public string Name { get; private set; }

    public Money Balance { get; private set; }

    public AccountStatus Status { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public DateTimeOffset ModifiedAt { get; private set; }

    public IReadOnlyCollection<SavingsGoal> SavingsGoals => _savingsGoals;

    public IReadOnlyCollection<Expense> Expenses => _expenses;

    public IReadOnlyCollection<Income> Incomes => _incomes;

    public IReadOnlyCollection<RecurringTransaction> RecurringTransactions => _recurringTransactions;

    public static Account Create(
        Ulid userId,
        string name,
        Money balance,
        TimeProvider timeProvider)
    {
        var account = new Account
        {
            UserId = userId,
            Name = name,
            Balance = balance,
            Status = AccountStatus.Active,
            CreatedAt = timeProvider.GetUtcNow(),
            ModifiedAt = timeProvider.GetUtcNow(),
        };

        return account;
    }

    public Result Transfer(
        Account targetAccount,
        Money amount,
        decimal currencyRate,
        DateTimeOffset modifiedAt)
    {
        if (Id == targetAccount.Id)
        {
            return Result.Failure(AccountErrors.TransferAccountConflict);
        }

        if (amount.Amount <= 0)
        {
            return Result.Failure(AccountErrors.InvalidAmount);
        }

        if (Balance < amount)
        {
            return Result.Failure(AccountErrors.InsufficientBalance);
        }

        if (Balance.Currency.Code != amount.Currency.Code)
        {
            return Result.Failure(AccountErrors.DifferentCurrency);
        }

        Balance -= amount;

        if (Balance.Currency.Code == targetAccount.Balance.Currency.Code)
        {
            currencyRate = 1;
        }

        targetAccount.Balance += amount.Amount * currencyRate;

        ModifiedAt = modifiedAt;
        targetAccount.ModifiedAt = modifiedAt;

        RaiseDomainEvent(new AccountTransferCompletedDomainEvent(
            UserId,
            Id,
            targetAccount.Id,
            amount,
            currencyRate,
            modifiedAt));

        return Result.Success();
    }

    public void Update(string name, AccountStatus status)
    {
        Name = name;
        Status = status;
    }

    public void AddExpenses(params Expense[] expenses)
    {
        _expenses.AddRange(expenses);
    }

    public void AddIncomes(params Income[] incomes)
    {
        _incomes.AddRange(incomes);
    }

    public void AddRange(params RecurringTransaction[] recurringTransactions)
    {
        _recurringTransactions.AddRange(recurringTransactions);
    }
}
