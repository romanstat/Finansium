using Finansium.Domain.Users;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.Property(notification => notification.Title)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(notification => notification.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(notification => notification.CreatedAt)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();

        builder.Property(notification => notification.IsViewed)
            .HasDefaultValue(false)
            .IsRequired();
    }
}
