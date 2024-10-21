namespace Finansium.Domain.Accounts;

public sealed class AccountTransfer : Entity
{
    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public Ulid SourceAccountId { get; private set; }

    public Account? SourceAccount { get; private set; }

    public Ulid TargetAccountId { get; private set; }

    public Account? TargetAccount { get; private set; }

    public Money Amount { get; private set; }

    public decimal CurrencyRate { get; private set; }

    public DateTimeOffset TransferDate { get; private set; }

    public static AccountTransfer Create(
        Ulid userId,
        Ulid sourceAccountId,
        Ulid targetAccountId,
        Money amount,
        decimal currencyRate,
        DateTimeOffset transferDate)
    {
        var accountTransfer = new AccountTransfer
        {
            UserId = userId,
            SourceAccountId = sourceAccountId,
            TargetAccountId = targetAccountId,
            Amount = amount,
            CurrencyRate = currencyRate,
            TransferDate = transferDate
        };

        return accountTransfer;
    }
}
