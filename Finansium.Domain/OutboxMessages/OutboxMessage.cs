namespace Finansium.Domain.OutboxMessages;

public sealed class OutboxMessage : Entity
{
    public DateTimeOffset OccurredAt { get; private set; }

    public string Type { get; private set; }

    public string Content { get; private set; }

    public DateTimeOffset? ProcessedAt { get; private set; }

    public string? Error { get; private set; }

    public static OutboxMessage Create(
        DateTimeOffset occurredAt,
        string type,
        string content)
    {
        var outboxMessage = new OutboxMessage
        {
            OccurredAt = occurredAt,
            Type = type,
            Content = content
        };

        return outboxMessage;
    }
}
