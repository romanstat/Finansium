namespace Finansium.Application.Categories.Commands.UpdateBudget;

public sealed record UpdateCategoryBudgetCommand(List<BudgetRequest> Budgets) : ICommand;
