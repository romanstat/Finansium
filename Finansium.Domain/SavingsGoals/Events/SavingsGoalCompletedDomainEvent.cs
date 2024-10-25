namespace Finansium.Domain.SavingsGoals.Events;

public sealed record SavingsGoalCompletedDomainEvent(Ulid Id) : IDomainEvent;
