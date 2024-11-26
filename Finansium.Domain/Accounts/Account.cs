using Finansium.Domain.Accounts.Events;
using Finansium.Domain.RecurringTransactions;
using Finansium.Domain.SavingsGoals;
using Finansium.Domain.Transactions;

namespace Finansium.Domain.Accounts;

/// <summary>
/// Счета пользователя
/// </summary>
public sealed class Account : Entity
{
    private readonly List<SavingsGoal> _savingsGoals = [];
    private readonly List<Transaction> _transactions = [];
    private readonly List<RecurringTransaction> _recurringTransactions = [];

    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public string Name { get; private set; }

    public Money Balance { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public DateTimeOffset ModifiedAt { get; private set; }

    public IReadOnlyCollection<SavingsGoal> SavingsGoals => _savingsGoals;

    public IReadOnlyCollection<Transaction> Transactions => _transactions;

    public IReadOnlyCollection<RecurringTransaction> RecurringTransactions => _recurringTransactions;

    public static Account Create(
        Ulid userId,
        string name,
        Money balance,
        DateTimeOffset createdAt)
    {
        var account = new Account
        {
            UserId = userId,
            Name = name,
            Balance = balance,
            CreatedAt = createdAt,
            ModifiedAt = createdAt,
        };

        return account;
    }

    public Result Transfer(
        Account targetAccount,
        Money amount,
        decimal currencyRate,
        DateTimeOffset modifiedAt)
    {
        const decimal SameCurrencyRate = 1;
        
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
            currencyRate = SameCurrencyRate;
        }

        targetAccount.Balance += amount.Amount * currencyRate;

        ModifiedAt = modifiedAt;
        targetAccount.ModifiedAt = modifiedAt;

        RaiseDomainEvent(new AccountTransferCompletedDomainEvent(
            Id,
            targetAccount.Id,
            amount,
            currencyRate,
            modifiedAt));

        return Result.Success();
    }

    public void Update(string name)
    {
        Name = name;
    }

    public void AddTransactions(params Transaction[] transactions)
    {
        _transactions.AddRange(transactions);
    }

    public void AddRange(params RecurringTransaction[] recurringTransactions)
    {
        _recurringTransactions.AddRange(recurringTransactions);
    }
}
