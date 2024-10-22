using Finansium.Domain.Categories;

namespace Finansium.Application.Categories.Commands.CreateIncome;

internal sealed class CreateIncomeCategoryCommandHandler(
    IUserContext userContext,
    ICategoryRepository categoryRepository)
    : ICommandHandler<CreateIncomeCategoryCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        CreateIncomeCategoryCommand request,
        CancellationToken cancellationToken)
    {
        if (!await categoryRepository.IsNameUnique(
            request.Name,
            CategoryType.Income,
            cancellationToken))
        {
            return Result.Failure<Ulid>(CategoryErrors.UniqueName(request.Name));
        }

        var category = Category.Create(
            userContext.UserId,
            request.Name,
            CategoryType.Income);

        categoryRepository.Add(category);

        return category.Id;
    }
}
