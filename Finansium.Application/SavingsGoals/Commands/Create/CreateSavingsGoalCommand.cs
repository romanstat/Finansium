namespace Finansium.Application.SavingsGoals.Commands.Create;

public sealed record CreateSavingsGoalCommand(
    Ulid AccountId,
    string Name,
    decimal TargetAmount,
    string Currency,
    string Note,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate) : ICommand<Ulid>;
