namespace Finansium.Domain.Categories;

public sealed record CategoryType(string Name)
{
    public static readonly CategoryType Income = new("Income");
    public static readonly CategoryType Expense = new("Expense");

    public static readonly IReadOnlyCollection<CategoryType> All =
    [
        Income,
        Expense
    ];

    public static CategoryType FromName(string name) =>
        All.FirstOrDefault(c => c.Name == name) ??
            throw new ApplicationException("The category type is invalid");
}
