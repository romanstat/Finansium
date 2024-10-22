namespace Finansium.Application.News.Queries.Search;

public sealed record SearchNewsQuery : IQuery<IReadOnlyList<NewsResponse>>;
