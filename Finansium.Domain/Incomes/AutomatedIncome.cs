namespace Finansium.Domain.Incomes;

public sealed class AutomatedIncome : Entity
{
    public Ulid UserId { get; private set; }

    public User User { get; private set; }

    public decimal Amount { get; private set; }

    public DateTimeOffset? NextPaymentDate { get; private set; }

    public TimeSpan? RecurrenceInterval { get; private set; }
}
