namespace Finansium.Application.RecurringTransactions.Commands.Update;

public sealed record UpdateRecurringTransactionCommand(
    Ulid Id,
    Ulid AccountId,
    decimal Amount,
    string Type,
    TimeSpan Interval,
    string Description,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate
    ) : ICommand<Ulid>;
