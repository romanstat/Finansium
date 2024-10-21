namespace Finansium.Domain.Accounts.Events;

public sealed record AccountTransferCompletedDomainEvent(
    Ulid UserId,
    Ulid SourceAccountId,
    Ulid TargetAccountId,
    Money Amount,
    decimal CurrencyRate,
    DateTimeOffset TransferDate) : IDomainEvent;
