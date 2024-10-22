namespace Finansium.Application.News.Queries.Search;

internal sealed class SearchNewsQueryHandler(IFinansiumDbContext dbContext)
    : IQueryHandler<SearchNewsQuery, IReadOnlyList<NewsResponse>>
{
    public async Task<Result<IReadOnlyList<NewsResponse>>> Handle(
        SearchNewsQuery request, 
        CancellationToken cancellationToken)
    {
        var categories = await dbContext.NewsItems
            .Where(news => !news.IsOutDated)
            .Select(news => new NewsResponse(
                news.Id,
                news.Title,
                news.Description,
                news.CreatedAt))
            .ToListAsync(cancellationToken);

        return categories;
    }
}
