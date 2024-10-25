using Finansium.Domain.Budgets;

namespace Finansium.Domain.Categories;

/// <summary>
/// Категории
/// </summary>
public sealed class Category : Entity
{
    private readonly List<Budget> _budget = [];

    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public Ulid? BudgetId { get; private set; }

    public string Name { get; private set; }

    public TransactionType TransactionType { get; private set; }

    public IReadOnlyCollection<Budget> Budgets => _budget;

    public static Category Create(
        Ulid userId,
        string name,
        TransactionType transactionType)
    {
        var category = new Category
        {
            UserId = userId,
            Name = name,
            TransactionType = transactionType
        };

        return category;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void AddBudget(Budget budget)
    {
        _budget.Add(budget);
    }
}
