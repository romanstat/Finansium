using Finansium.Domain.Incomes;

namespace Finansium.Domain.Categories;

/// <summary>
/// Категории для доходов
/// </summary>
public sealed class IncomeCategory : Entity
{
    private readonly List<Income> _incomes = [];

    public Ulid UserId { get; private set; }

    public User User { get; private set; }

    public string Name { get; private set; }

    public IReadOnlyCollection<Income> Incomes => _incomes;
}
