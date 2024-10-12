namespace Finansium.Domain.SavingsGoals;

/// <summary>
/// Цели накоплений
/// </summary>
public sealed class SavingsGoal : Entity
{
    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public string Name { get; private set; }

    public decimal CurrentAmount { get; private set; }

    public decimal TargetAmount { get; private set; }

    public DateTimeOffset StartDate { get; private set; }

    public DateTimeOffset EndDate { get; private set; }

    public static SavingsGoal Create(
        Ulid userId,
        string name,
        decimal currentAmount,
        decimal targetAmount,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
    {
        var savingsGoal = new SavingsGoal
        {
            UserId = userId,
            Name = name,
            CurrentAmount = currentAmount,
            TargetAmount = targetAmount,
            StartDate = startDate,
            EndDate = endDate
        };

        return savingsGoal;
    }
}
