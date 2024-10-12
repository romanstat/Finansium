using Finansium.Domain.Accounts;

namespace Finansium.Domain.Incomes;

/// <summary>
/// Доходы
/// </summary>
public sealed class Income : Entity
{
    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public Ulid AcoountId { get; private set; }

    public Account? Account { get; private set; }

    public decimal Amount { get; private set; }

    public DateTimeOffset Date { get; private set; }
}
