namespace Finansium.Application.Categories.Commands.CreateBudget;

public sealed record CreateCategoryBudgetCommand(
    Ulid CategoryId,
    string BudgetType,
    decimal LimitAmount) : ICommand<Ulid>;
