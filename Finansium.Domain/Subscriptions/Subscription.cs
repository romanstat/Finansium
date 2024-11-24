namespace Finansium.Domain.Subscriptions;

public sealed class Subscription : Entity
{
    public SubscriptionType Type { get; private set; }

    public DateTimeOffset StartAt { get; private set; }

    public DateTimeOffset ExpiredAt { get; private set; }

    public static Subscription Create(
        SubscriptionType type,
        DateTimeOffset startAt)
    {
        var subscription = new Subscription
        {
            Type = type,
            StartAt = startAt,
            ExpiredAt = type.CalculateExpiration(startAt)
        };

        return subscription;
    }
}
