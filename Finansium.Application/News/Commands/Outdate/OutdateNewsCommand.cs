namespace Finansium.Application.News.Commands.Outdate;

public sealed record OutdateNewsCommand(Ulid Id) : ICommand;
