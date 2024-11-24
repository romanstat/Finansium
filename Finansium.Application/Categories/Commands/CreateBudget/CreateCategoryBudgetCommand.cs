namespace Finansium.Application.Categories.Commands.CreateBudget;

public sealed record CreateCategoryBudgetCommand(
    Ulid Id,
    Ulid CategoryId,
    string Type,
    decimal LimitAmount) : ICommand<Ulid>;
