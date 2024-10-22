using Finansium.Domain.Categories;

namespace Finansium.Application.Categories.Commands.Update;

internal sealed class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository)
    : ICommandHandler<UpdateCategoryCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        UpdateCategoryCommand request, 
        CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.Id, cancellationToken);

        if (category is null)
        {
            return Result.Failure<Ulid>(CategoryErrors.NotFound(request.Id));
        }

        category.UpdateName(request.Name);

        return category.Id;
    }
}
