namespace Finansium.Domain.SavingsGoals;

/// <summary>
/// Цели накоплений
/// </summary>
public sealed class SavingsGoal : Entity
{
    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public string Name { get; private set; }

    public Money Current { get; private set; }

    public Money Target { get; private set; }

    public DateTimeOffset StartDate { get; private set; }

    public DateTimeOffset EndDate { get; private set; }

    public static SavingsGoal Create(
        Ulid userId,
        string name,
        Money current,
        Money target,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
    {
        var savingsGoal = new SavingsGoal
        {
            UserId = userId,
            Name = name,
            Current = current,
            Target = target,
            StartDate = startDate,
            EndDate = endDate
        };

        return savingsGoal;
    }
}
