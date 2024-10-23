namespace Finansium.Application.RecurringTransactions.Commands.Delete;

public sealed record DeleteRecurringTransactionCommand(Ulid Id) : ICommand;
