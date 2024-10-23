using Finansium.Domain.Accounts;
using Finansium.Domain.Categories;

namespace Finansium.Domain.Incomes;

/// <summary>
/// Доходы
/// </summary>
public sealed class Income : Entity
{
    public Ulid CategoryId { get; private set; }

    public Category? Category { get; private set; }

    public Ulid AccountId { get; private set; }

    public Account? Account { get; private set; }

    public Money Amount { get; private set; }

    public DateTimeOffset Date { get; private set; }

    public static Income Create(
        Ulid categoryId,
        Money amount,
        DateTimeOffset date)
    {
        var income = new Income
        {
            CategoryId = categoryId,
            Amount = amount,
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
