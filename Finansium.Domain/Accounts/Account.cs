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
        if (amount.Amount <= 0)
        {
            return Result.Failure(AccountErrors.InvalidAmount);
        }

        if (Balance < amount)
        {
            return Result.Failure(AccountErrors.InsufficientBalance);
        }

        Balance -= amount;

        targetAccount.Balance += amount.Amount * conversionRate;

        ModifiedAt = timeProvider.GetUtcNow();

        return Result.Success();
    }
}
