namespace Finansium.Application.News.Queries.Search;

public sealed record NewsResponse(
    Ulid Id,
    string Title,
    string Description,
    DateTimeOffset CreatedAt);
