using Finansium.Domain.Accounts;
using Finansium.Domain.Categories;

namespace Finansium.Domain.Transactions;

public sealed class Transaction : Entity
{
    public Ulid AccountId { get; private set; }

    public Account? Account { get; private set; }

    public Ulid CategoryId { get; private set; }

    public Category? Category { get; private set; }

    public TransactionType Type { get; private set; }

    public Money Amount { get; private set; }

    public DateTimeOffset Date { get; private set; }

    public string? Description { get; private set; }

    public static Transaction Create(
        Ulid categoryId,
        TransactionType type,
        Money amount,
        DateTimeOffset date,
        string? description = default)
    {
        var transaction = new Transaction
        {
            CategoryId = categoryId,
            Type = type,
            Amount = amount,
            Date = date,
            Description = description
        };

        return transaction;
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
