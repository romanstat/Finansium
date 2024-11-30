namespace Finansium.Application.Categories.Commands.UpdateBudget;

public sealed record BudgetRequest(Ulid Id, decimal LimitAmount);
