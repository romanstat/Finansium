using Finansium.Domain.Subscriptions;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.Property(subscription => subscription.Type)
            .HasConversion(type => type.Name, name => SubscriptionType.FromName(name));
    }
}
