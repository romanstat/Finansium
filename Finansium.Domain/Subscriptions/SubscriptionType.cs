namespace Finansium.Domain.Subscriptions;

public abstract record SubscriptionType(string Name, decimal Price)
{
    public sealed record FreeSubscription() : SubscriptionType("Free", 0.0M)
    {
        public override DateTimeOffset CalculateExpiration(DateTimeOffset startDate) => DateTimeOffset.MaxValue;
    }

    public sealed record TrialSubscription() : SubscriptionType("Trial", 0.00M)
    {
        public override DateTimeOffset CalculateExpiration(DateTimeOffset startDate) => startDate.AddDays(14);
    }

    public sealed record BasicSubscription() : SubscriptionType("Basic", 1.99M)
    {
        public override DateTimeOffset CalculateExpiration(DateTimeOffset startDate) => startDate.AddMonths(1);
    }

    public sealed record AdvancedSubscription() : SubscriptionType("Advanced", 4.99M)
    {
        public override DateTimeOffset CalculateExpiration(DateTimeOffset startDate) => startDate.AddMonths(1);
    }

    public sealed record PremiumSubscription() : SubscriptionType("Premium", 9.99M)
    {
        public override DateTimeOffset CalculateExpiration(DateTimeOffset startDate) => startDate.AddMonths(1);
    }

    public static readonly IReadOnlyList<SubscriptionType> All =
    [
        new FreeSubscription(),
        new TrialSubscription(),
        new BasicSubscription(),
        new AdvancedSubscription(),
        new PremiumSubscription()
    ];

    public static SubscriptionType FromName(string name) =>
        All.FirstOrDefault(c => c.Name == name) ??
            throw new ApplicationException("The subcription type is invalid");

    public abstract DateTimeOffset CalculateExpiration(DateTimeOffset startDate);
}
