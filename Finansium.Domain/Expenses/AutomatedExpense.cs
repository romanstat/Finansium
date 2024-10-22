using Finansium.Domain.Categories;

namespace Finansium.Domain.Expenses;

public sealed class AutomatedExpense : Entity
{
    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public Ulid CategoryId { get; private set; }

    public Category? Category { get; private set; }

    public decimal Amount { get; private set; }

    public DateTimeOffset? NextPaymentDate { get; private set; }

    public TimeSpan? RecurrenceInterval { get; private set; }
}
