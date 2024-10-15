namespace Finansium.Domain.Accounts;

public sealed class AccountTransfer : Entity
{
    public Ulid SourceAccountId { get; init; }

    public Account SourceAccount { get; init; }

    public Ulid TargetAccountId { get; init; }

    public Account TargetAccount { get; init; }

    public Money Amount { get; init; }

    public decimal ConversionRate { get; init; }
}
