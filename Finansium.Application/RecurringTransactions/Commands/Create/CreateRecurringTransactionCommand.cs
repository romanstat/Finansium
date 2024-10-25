namespace Finansium.Application.RecurringTransactions.Commands.Create;

public sealed record CreateRecurringTransactionCommand(
    Ulid AccountId,
    decimal Amount,
    string Type,
    TimeSpan Interval,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    string? Description) : ICommand<Ulid>;
