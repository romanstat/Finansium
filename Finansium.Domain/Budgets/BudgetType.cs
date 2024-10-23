namespace Finansium.Domain.Budgets;

public sealed record BudgetType(string Name)
{
    public static readonly BudgetType Weekly = new("Weekly");
    public static readonly BudgetType Monthly = new("Monthly");
    public static readonly BudgetType Annual = new("Annual");

    public static readonly IReadOnlyCollection<BudgetType> All =
    [
        Weekly,
        Monthly,
        Annual
    ];

    public static BudgetType FromName(string name) =>
        All.FirstOrDefault(c => c.Name == name) ??
            throw new ApplicationException("The budget type is invalid");
}
