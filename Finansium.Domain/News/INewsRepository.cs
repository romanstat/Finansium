
namespace Finansium.Domain.News;

public interface INewsRepository
{
    Task<NewsItem?> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
    void Add(NewsItem news);
}
