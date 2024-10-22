using Finansium.Domain.Categories;

namespace Finansium.Application.Categories.Commands.Delete;

internal sealed class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    : ICommandHandler<DeleteCategoryCommand>
{
    public async Task<Result> Handle(
        DeleteCategoryCommand request, 
        CancellationToken cancellationToken)
    {
        await categoryRepository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
