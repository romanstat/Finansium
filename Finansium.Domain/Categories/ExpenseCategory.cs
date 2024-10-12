using Finansium.Domain.Expenses;

namespace Finansium.Domain.Categories;

/// <summary>
/// Категории для расходов
/// </summary>
public sealed class ExpenseCategory : Entity
{
    private readonly List<Expense> _expenses = [];

    public Ulid UserId { get; private set; }

    public User User { get; private set; }

    public string Name { get; private set; }

    public decimal? MonthlyLimit { get; private set; }

    public IReadOnlyCollection<Expense> Expenses => _expenses;
}
