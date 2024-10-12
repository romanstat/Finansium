namespace Finansium.Domain.Accounts;

public sealed class AccoutTransfer : Entity
{
    public Ulid SourceAccountId { get; init; }

    public Account SourceAccount { get; init; }

    public Ulid TargetAccountId { get; init; }

    public Account TargetAccount { get; init; }

    public decimal Amount { get; init; }

    public decimal ConversionRate { get; init; }
}
