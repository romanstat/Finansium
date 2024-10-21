namespace Finansium.Application.SavingsGoals.Queries.GetList;

public sealed record SavingsGoalResponse(
    Ulid Id,
    string Name,
    decimal CurrentAmount,
    decimal TargetAmount,
    string Currency,
    string Note,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    bool IsCompleted);
