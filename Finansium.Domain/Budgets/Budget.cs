using Finansium.Domain.Categories;

namespace Finansium.Domain.Budgets;

/// <summary>
/// Бюджет на категорию
/// </summary>
public sealed class Budget : Entity
{
    public Ulid CategoryId { get; private set; }

    public Category? Category { get; private set; }

    public BudgetType Type { get; private set; }

    public decimal LimitAmount { get; private set; }

    public static Budget Create(
        BudgetType type,
        decimal limitAmount)
    {
        var budget = new Budget
        {
            Type = type,
            LimitAmount = limitAmount,
        };

        return budget;
    }

    public void ChangeAmount(decimal limitAmount)
    {
        LimitAmount = limitAmount;
    }
}
