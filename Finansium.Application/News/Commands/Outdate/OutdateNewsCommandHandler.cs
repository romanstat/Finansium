using Finansium.Domain.News;

namespace Finansium.Application.News.Commands.Outdate;

internal sealed class OutdateNewsCommandHandler(INewsRepository newsRepository)
    : ICommandHandler<OutdateNewsCommand>
{
    public async Task<Result> Handle(
        OutdateNewsCommand request, 
        CancellationToken cancellationToken)
    {
        var news = await newsRepository.GetByIdAsync(request.Id, cancellationToken);

        if (news is null)
        {
            return Result.Failure(NewsErrors.NotFound(request.Id));
        }

        news.OutDate();

        return Result.Success();
    }
}
