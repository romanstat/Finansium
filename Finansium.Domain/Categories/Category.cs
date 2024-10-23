using Finansium.Domain.Budgets;
using Finansium.Domain.Expenses;
using Finansium.Domain.Incomes;

namespace Finansium.Domain.Categories;

/// <summary>
/// Категории
/// </summary>
public sealed class Category : Entity
{
    private readonly List<Income> _incomes = [];
    private readonly List<Expense> _expenses = [];
    private readonly List<Budget> _budgets = [];

    public Ulid UserId { get; private set; }

    public User User { get; private set; }

    public string Name { get; private set; }

    public TransactionType TransactionType { get; private set; }

    public IReadOnlyCollection<Income> Incomes => _incomes;

    public IReadOnlyCollection<Expense> Expenses => _expenses;

    public IReadOnlyCollection<Budget> Budgets => _budgets;

    public static Category Create(
        Ulid userId,
        string Name,
        TransactionType transactionType)
    {
        var category = new Category
        {
            UserId = userId,
            Name = Name,
            TransactionType = transactionType
        };

        return category;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void AddBudgets(params Budget[] budgets)
    {
        _budgets.AddRange(budgets);
    }
}
