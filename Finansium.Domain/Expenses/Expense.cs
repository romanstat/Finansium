using Finansium.Domain.Accounts;
using Finansium.Domain.Categories;

namespace Finansium.Domain.Expenses;

/// <summary>
/// Расходы
/// </summary>
public sealed class Expense : Entity
{
    public Ulid AccountId { get; private set; }

    public Account? Account { get; private set; }

    public Ulid CategoryId { get; private set; }

    public Category? Category { get; private set; }

    public Money Amount { get; private set; }

    public string Description { get; private set; }

    public DateTimeOffset Date { get; private set; }

    public static Expense Create(
        Ulid categoryId,
        Money amount,
        string description,
        DateTimeOffset date)
    {
        var income = new Expense
        {
            CategoryId = categoryId,
            Amount = amount,
            Description = description,
            Date = date
        };

        return income;
    }

    public void Update(
        Ulid categoryId, 
        Ulid accountId, 
        Money amount, 
        DateTimeOffset date)
    {
        CategoryId = categoryId;
        AccountId = accountId;
        Amount = amount;
        Date = date;
    }
}
