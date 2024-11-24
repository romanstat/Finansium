using Finansium.Domain.News;

namespace Finansium.Application.News.Commands.Update;

internal sealed class UpdateNewsCommandHandler(
    INewsRepository newsRepository)
    : ICommandHandler<UpdateNewsCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        UpdateNewsCommand request,
        CancellationToken cancellationToken)
    {
        var news = await newsRepository.GetByIdAsync(request.Id, cancellationToken);

        if (news is null)
        {
            return Result.Failure<Ulid>(NewsErrors.NotFound(request.Id));
        }

        news.Update(request.Title, request.Description);

        return await Task.FromResult(news.Id);
    }
}
