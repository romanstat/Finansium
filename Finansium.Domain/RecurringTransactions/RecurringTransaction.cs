using Finansium.Domain.Accounts;

namespace Finansium.Domain.RecurringTransactions;

public sealed class RecurringTransaction : Entity
{
    public Ulid AccountId { get; private set; }

    public Account? Account { get; private set; }

    public TransactionType Type { get; private set; }

    public Money Amount { get; private set; }

    public TimeSpan Interval { get; private set; }

    public DateTimeOffset StartDate { get; private set; }

    public DateTimeOffset EndDate { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public DateTimeOffset? NextPaymentDate { get; private set; }

    public string? Description { get; private set; }

    public static RecurringTransaction Create(
        Ulid accountId,
        Money amount,
        TransactionType transactionType,
        TimeSpan interval,
        DateTimeOffset startDate,
        DateTimeOffset endDate,
        DateTimeOffset createdAt,
        string? description = default)
    {
        var recurringTransaction = new RecurringTransaction
        {
            AccountId = accountId,
            Amount = amount,
            Type = transactionType,
            Interval = interval,
            Description = description,
            StartDate = startDate,
            EndDate = endDate,
            CreatedAt = createdAt
        };

        recurringTransaction.UpdateNextPaymentDate(createdAt);

        return recurringTransaction;
    }

    public void Update(
        Ulid accountId,
        Money amount,
        TransactionType transactionType,
        TimeSpan interval,
        string description,
        DateTimeOffset startDate,
        DateTimeOffset endDate,
        DateTimeOffset currentDate)
    {
        AccountId = accountId;
        Amount = amount;
        Type = transactionType;
        Interval = interval;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;

        UpdateNextPaymentDate(currentDate);
    }

    private void UpdateNextPaymentDate(DateTimeOffset currentDate)
    {
        var date = StartDate;

        if (currentDate > StartDate)
        {
            date = currentDate;
        }

        NextPaymentDate = date + Interval;
    }
}
