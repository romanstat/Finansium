namespace Finansium.Domain.Abstractions;

public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        Id = Ulid.NewUlid();
        OccurredOnUtc = TimeProvider.System.GetUtcNow();
    }

    protected DomainEvent(
        Ulid id,
        DateTimeOffset occurredOnUtc)
    {
        Id = id;
        OccurredOnUtc = occurredOnUtc;
    }

    public Ulid Id { get; init; }

    public DateTimeOffset OccurredOnUtc { get; init; }
}
