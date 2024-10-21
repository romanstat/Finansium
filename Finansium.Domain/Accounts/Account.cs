namespace Finansium.Domain.Accounts;

/// <summary>
/// Счета пользователя
/// </summary>
public sealed class Account : Entity
{
    public Ulid UserId { get; private set; }

    public User User { get; private set; }

    public string Name { get; private set; }

    public Money Balance { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public DateTimeOffset ModifiedAt { get; private set; }

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
            CreatedAt = timeProvider.GetUtcNow(),
            ModifiedAt = timeProvider.GetUtcNow(),
        };

        return account;
    }

    public Result Transfer(
        Account targetAccount,
        Money amount,
        decimal conversionRate,
        TimeProvider timeProvider)
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
            conversionRate = 1;
        }

        targetAccount.Balance += amount.Amount * conversionRate;

        ModifiedAt = timeProvider.GetUtcNow();
        targetAccount.ModifiedAt = timeProvider.GetUtcNow();

        return Result.Success();
    }

    public void Update(string name, Money balance)
    {
        Name = name;
        Balance = balance;
    }
}
