namespace Finansium.Application.RecurringTransactions.Commands.Create;

public sealed record CreateRecurringTransactionCommand(
    Ulid AccountId,
    decimal Amount,
    string Type,
    TimeSpan Interval,
    string Description,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate
    ) : ICommand<Ulid>;
