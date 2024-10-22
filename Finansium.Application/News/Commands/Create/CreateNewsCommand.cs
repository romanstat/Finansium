namespace Finansium.Application.News.Commands.Create;

public sealed record CreateNewsCommand(
    string Title,
    string Description) : ICommand<Ulid>;
