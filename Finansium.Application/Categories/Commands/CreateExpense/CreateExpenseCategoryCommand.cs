namespace Finansium.Application.Categories.Commands.CreateExpense;

public sealed record CreateExpenseCategoryCommand(string Name) : ICommand<Ulid>;
