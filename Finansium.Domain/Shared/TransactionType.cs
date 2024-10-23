namespace Finansium.Domain.Shared;

public sealed record TransactionType(string Name)
{
    public static readonly TransactionType Income = new("Income");
    public static readonly TransactionType Expense = new("Expense");

    public static readonly IReadOnlyCollection<TransactionType> All =
    [
        Income,
        Expense
    ];

    public static TransactionType FromName(string name) =>
        All.FirstOrDefault(c => c.Name == name) ??
            throw new ApplicationException("The transaction type is invalid");
}
