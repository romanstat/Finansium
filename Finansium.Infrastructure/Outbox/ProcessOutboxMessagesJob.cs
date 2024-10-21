using System.Transactions;
using Finansium.Persistence.Database;
using Finansium.Persistence.Extensions;

namespace Finansium.Infrastructure.Outbox;

[DisallowConcurrentExecution]
internal sealed class ProcessOutboxMessagesJob(
    TimeProvider timeProvider,
    IUnitOfWork unitOfWork,
    FinansiumDbContext dbContext,
    IPublisher publisher,
    IOptionsMonitor<OutboxOptions> outboxOptions,
    ILogger<ProcessOutboxMessagesJob> logger) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        logger.LogInformation("Beginning to process outbox messages");

        using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var outboxMessages = await GetOutboxMessagesAsync();

        foreach (var outboxMessage in outboxMessages)
        {
            Exception? exception = null;

            try
            {
                var domainEvent = JsonSerializer.Deserialize<IDomainEvent>(
                    outboxMessage.Content,
                    JsonExtensions.DomainSerializationOptions)!;

                await publisher.Publish(domainEvent, context.CancellationToken);
            }
            catch (Exception caughtException)
            {
                logger.LogError(
                    caughtException,
                    "Exception while processing outbox message {MessageId}",
                    outboxMessage.Id);

                exception = caughtException;
            }

            await UpdateOutboxMessageAsync(outboxMessage, exception);
        }

        await unitOfWork.SaveChangesAsync();

        transaction.Complete();

        logger.LogInformation("Completed processing outbox messages");
    }

    private async Task<List<OutboxMessageResponse>> GetOutboxMessagesAsync()
    {
        var outboxMessages = await dbContext.OutboxMessages
            .Where(outboxMessage => outboxMessage.ProcessedOnUtc == null)
            .OrderBy(outboxMessage => outboxMessage.ProcessedOnUtc)
            .Take(outboxOptions.CurrentValue.BatchSize)
            .Select(outboxMessage => new OutboxMessageResponse(
                outboxMessage.Id,
                outboxMessage.Type,
                outboxMessage.Content))
            .ToListAsync();

        return outboxMessages;
    }

    private async Task UpdateOutboxMessageAsync(
        OutboxMessageResponse outboxMessage,
        Exception? exception)
    {
        var error = exception?.ToString() ?? string.Empty;

        await dbContext.OutboxMessages
            .Where(outbox => outbox.Id == outboxMessage.Id)
            .ExecuteUpdateAsync(outbox => outbox
                .SetProperty(p => p.ProcessedOnUtc, p => timeProvider.GetUtcNow())
                .SetProperty(p => p.Error, p => error));
    }

    internal sealed record OutboxMessageResponse(Ulid Id, string Type, string Content);
}
