using Finansium.Domain.News;

namespace Finansium.Application.News.Commands.Create;

internal sealed class CreateNewsCommandHandler(
    INewsRepository newsRepository,
    TimeProvider timeProvider)
    : ICommandHandler<CreateNewsCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        CreateNewsCommand request, 
        CancellationToken cancellationToken)
    {
        var news = NewsItem.Create(
            request.Title,
            request.Description,
            timeProvider.GetUtcNow());

        newsRepository.Add(news);

        return await Task.FromResult(news.Id);
    }
}
