using Finansium.Domain.News;

namespace Finansium.Persistence.Repositories;

internal sealed class NewsRepository(FinansiumDbContext dbContext)
    : Repository<NewsItem>(dbContext), INewsRepository
{
}
