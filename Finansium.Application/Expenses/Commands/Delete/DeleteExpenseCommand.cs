namespace Finansium.Application.Incomes.Commands.Delete;

public sealed record DeleteExpenseCommand(Ulid Id) : ICommand;
