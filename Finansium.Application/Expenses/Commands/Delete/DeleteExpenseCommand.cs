namespace Finansium.Application.Expenses.Commands.Delete;

public sealed record DeleteExpenseCommand(Ulid Id) : ICommand;
