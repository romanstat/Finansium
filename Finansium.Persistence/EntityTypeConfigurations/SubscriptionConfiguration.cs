using Finansium.Domain.Subscriptions;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.Property(subscription => subscription.Type)
            .HasMaxLength(20)
            .HasConversion(type => type.Name, name => SubscriptionType.FromName(name))
            .IsRequired();

        builder.Property(subscription => subscription.StartAt)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();

        builder.Property(subscription => subscription.ExpiredAt)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();
    }
}
