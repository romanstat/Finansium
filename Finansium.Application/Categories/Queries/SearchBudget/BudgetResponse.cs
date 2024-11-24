namespace Finansium.Application.Categories.Queries.SearchBudget;

public sealed record BudgetResponse(
    Ulid Id,
    Ulid CategoryId,
    string Name,
    string Type,
    decimal LimitAmount);
