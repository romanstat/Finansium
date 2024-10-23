namespace Finansium.Application.Incomes.Commands.Delete;

public sealed record DeleteIncomeCommand(Ulid Id) : ICommand;
