namespace Finansium.Application.News.Commands.Update;

public sealed record UpdateNewsCommand(
    Ulid Id,
    string Title,
    string Description) : ICommand<Ulid>;
