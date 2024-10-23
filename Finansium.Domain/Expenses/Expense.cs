using Finansium.Domain.Accounts;
using Finansium.Domain.Categories;

namespace Finansium.Domain.Expenses;

/// <summary>
/// Расходы
/// </summary>
public sealed class Expense : Entity
{
    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public Ulid AccountId { get; private set; }

    public Account? Account { get; private set; }

    public Ulid CategoryId { get; private set; }

    public Category? Category { get; private set; }

    public Money Amount { get; private set; }

    public string Description { get; private set; }

    public DateTimeOffset Date { get; private set; }

    public static Expense Create(
        Ulid userId, 
        Ulid categoryId, 
        Ulid accountId, 
        Money amount, 
        string description, 
        DateTimeOffset date)
    {
        var income = new Expense
        {
            UserId = userId,
            CategoryId = categoryId,
            AccountId = accountId,
            Amount = amount,
            Description = description,
            Date = date
        };

        return income;
    }
}
