namespace Finansium.Application.SavingsGoals.Commands.Update;

public sealed record UpdateSavingsGoalCommand(
    Ulid Id,
    string Name,
    decimal TargetAmount) : ICommand;
