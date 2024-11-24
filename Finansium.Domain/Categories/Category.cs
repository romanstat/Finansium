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

        category.AddDefaultBudgets();

        return category;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    private void AddDefaultBudgets()
    {
        _budget.AddRange([
            Budget.Create(BudgetType.Weekly, 0),
            Budget.Create(BudgetType.Monthly, 0),
            Budget.Create(BudgetType.Annual, 0)]);
    }
}
