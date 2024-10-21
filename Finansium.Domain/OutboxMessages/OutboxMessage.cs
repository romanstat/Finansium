namespace Finansium.Domain.OutboxMessages;

public sealed class OutboxMessage : Entity
{
    public DateTimeOffset OccurredOnUtc { get; private set; }

    public string Type { get; private set; }

    public string Content { get; private set; }

    public DateTimeOffset? ProcessedOnUtc { get; private set; }

    public string? Error { get; private set; }

    public static OutboxMessage Create(
        DateTimeOffset occurredOnUtc,
        string type,
        string content)
    {
        var outboxMessage = new OutboxMessage
        {
            OccurredOnUtc = occurredOnUtc,
            Type = type,
            Content = content
        };

        return outboxMessage;
    }
}
