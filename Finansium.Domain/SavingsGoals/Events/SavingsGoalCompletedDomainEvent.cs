namespace Finansium.Domain.SavingsGoals.Events;

public sealed record SavingsGoalCompletedDomainEvent(
    Ulid SavingsGoalId,
    Ulid UserId) : IDomainEvent;
