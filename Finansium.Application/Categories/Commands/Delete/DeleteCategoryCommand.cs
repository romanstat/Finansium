namespace Finansium.Application.Categories.Commands.Delete;

public sealed record DeleteCategoryCommand(Ulid Id) : ICommand;
