namespace Finansium.Application.Expenses.Queries.Search;

public sealed record SearchExpenseQuery : IQuery<IReadOnlyList<ExpenseResponse>>;
