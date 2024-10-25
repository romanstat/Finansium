namespace Finansium.Domain.Accounts;

public sealed class AccountTransfer : Entity
{
    public Ulid SourceAccountId { get; private set; }

    public Account? SourceAccount { get; private set; }

    public Ulid TargetAccountId { get; private set; }

    public Account? TargetAccount { get; private set; }

    public Money Amount { get; private set; }

    public decimal CurrencyRate { get; private set; }

    public DateTimeOffset Date { get; private set; }

    public static AccountTransfer Create(
        Ulid sourceAccountId,
        Ulid targetAccountId,
        Money amount,
        decimal currencyRate,
        DateTimeOffset date)
    {
        var accountTransfer = new AccountTransfer
        {
            SourceAccountId = sourceAccountId,
            TargetAccountId = targetAccountId,
            Amount = amount,
            CurrencyRate = currencyRate,
            Date = date
        };

        return accountTransfer;
    }
}
