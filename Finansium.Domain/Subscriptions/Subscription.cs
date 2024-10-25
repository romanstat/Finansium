namespace Finansium.Domain.Subscriptions;

public sealed class Subscription : Entity
{
    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public SubscriptionType Type { get; private set; }

    public DateTimeOffset StartAt { get; private set; }

    public DateTimeOffset ExpiredAt { get; private set; }

    public static Subscription Create(
        Ulid userId,
        SubscriptionType type,
        DateTimeOffset startAt)
    {
        var subscription = new Subscription
        {
            UserId = userId,
            Type = type,
            StartAt = startAt,
            ExpiredAt = type.CalculateExpiration(startAt)
        };

        return subscription;
    }
}
