namespace Finansium.Application.SavingsGoals.Commands.Delete;

public sealed record DeleteSavingsGoalCommand(Ulid Id) : ICommand;

