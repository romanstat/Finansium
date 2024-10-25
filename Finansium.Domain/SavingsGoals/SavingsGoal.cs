using Finansium.Domain.Accounts;
using Finansium.Domain.SavingsGoals.Events;

namespace Finansium.Domain.SavingsGoals;

/// <summary>
/// Цели накоплений
/// </summary>
public sealed class SavingsGoal : Entity
{
    public Ulid AccountId { get; private set; }

    public Account? Account { get; private set; }

    public string Name { get; private set; }

    public Money TargetAmount { get; private set; }

    public string Note { get; private set; }

    public DateTimeOffset StartDate { get; private set; }

    public DateTimeOffset EndDate { get; private set; }

    public DateTimeOffset? CompletedDate { get; private set; }

    public bool IsCompleted { get; private set; }

    public static SavingsGoal Create(
        Ulid accountId,
        string name,
        Money targetAmount,
        string note,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
    {
        var savingsGoal = new SavingsGoal
        {
            AccountId = accountId,
            Name = name,
            TargetAmount = targetAmount,
            Note = note,
            StartDate = startDate,
            EndDate = endDate,
            IsCompleted = false
        };

        return savingsGoal;
    }

    public void UpdateStatus(Money currentAmount)
    {
        if (currentAmount >= TargetAmount)
        {
            IsCompleted = true;

            RaiseDomainEvent(new SavingsGoalCompletedDomainEvent(Id));
        }
    }
}
