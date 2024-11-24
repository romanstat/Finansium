namespace Finansium.Application.Categories.Queries.SearchBudget;

public sealed record SearchBudgetQuery(string Type) : IQuery<IReadOnlyList<BudgetResponse>>;
