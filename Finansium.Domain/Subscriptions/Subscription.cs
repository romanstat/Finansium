namespace Finansium.Domain.Subscriptions;

public sealed class Subscription : Entity
{
    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public SubscriptionType Type { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public DateTimeOffset ExpiredAt { get; private set; }

    public static Subscription Create(
        Ulid userId,
        SubscriptionType type,
        DateTimeOffset startDate)
    {
        var subscription = new Subscription
        {
            UserId = userId,
            Type = type,
            CreatedAt = startDate,
            ExpiredAt = type.CalculateExpiration(startDate)
        };

        return subscription;
    }
}
