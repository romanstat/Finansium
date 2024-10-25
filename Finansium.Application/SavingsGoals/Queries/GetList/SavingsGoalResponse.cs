namespace Finansium.Application.SavingsGoals.Queries.GetList;

public sealed record SavingsGoalResponse(
    Ulid Id,
    string Name,
    decimal CurrentAmount,
    decimal TargetAmount,
    Currency Currency,
    string Note,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    DateTimeOffset? CompletedDate,
    bool IsCompleted);
