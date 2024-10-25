using Finansium.Domain.OutboxMessages;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.Property(outboxMessage => outboxMessage.OccurredAt)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();

        builder.Property(outboxMessage => outboxMessage.Type)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(outboxMessage => outboxMessage.Content)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(outboxMessage => outboxMessage.ProcessedAt).IsRequired(false);

        builder.Property(outboxMessage => outboxMessage.Error)
            .HasMaxLength(5000)
            .IsRequired(false);
    }
}
