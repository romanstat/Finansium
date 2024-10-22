namespace Finansium.Application.Categories.Commands.Update;

public sealed record UpdateCategoryCommand(
    Ulid Id, 
    string Name) : ICommand<Ulid>;
