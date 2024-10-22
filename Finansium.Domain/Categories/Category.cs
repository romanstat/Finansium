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

    public Ulid UserId { get; private set; }

    public User User { get; private set; }

    public string Name { get; private set; }

    public CategoryType Type { get; private set; }

    public IReadOnlyCollection<Income> Incomes => _incomes;

    public IReadOnlyCollection<Expense> Expenses => _expenses;

    public static Category Create(
        Ulid userId,
        string Name,
        CategoryType type)
    {
        var category = new Category
        {
            UserId = userId,
            Name = Name,
            Type = type
        };

        return category;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}
