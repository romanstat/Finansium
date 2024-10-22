namespace Finansium.Application.Categories.Commands.CreateIncome;

public sealed record CreateIncomeCategoryCommand(string Name) : ICommand<Ulid>;
