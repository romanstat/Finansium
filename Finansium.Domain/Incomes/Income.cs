using Finansium.Domain.Accounts;
using Finansium.Domain.Categories;

namespace Finansium.Domain.Incomes;

/// <summary>
/// Доходы
/// </summary>
public sealed class Income : Entity
{
    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public Ulid CategoryId { get; private set; }

    public Category? Category { get; private set; }

    public Ulid AccountId { get; private set; }

    public Account? Account { get; private set; }

    public Money Amount { get; private set; }

    public DateTimeOffset Date { get; private set; }

    public static Income Create(
        Ulid userId,
        Ulid categoryId,
        Ulid accountId,
        Money amount,
        DateTimeOffset dateTimeOffset)
    {
        var income = new Income
        {
            UserId = userId,
            CategoryId = categoryId,
            AccountId = accountId,
            Amount = amount,
            Date = dateTimeOffset
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
