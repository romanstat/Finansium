using Finansium.Domain.Categories;

namespace Finansium.Application.Categories.Commands.CreateExpense;

internal sealed class CreateExpenseCategoryCommandHandler(
    IUserContext userContext,
    ICategoryRepository categoryRepository)
    : ICommandHandler<CreateExpenseCategoryCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        CreateExpenseCategoryCommand request, 
        CancellationToken cancellationToken)
    {
        if (!await categoryRepository.IsNameUnique(
            Ulid.Empty,
            request.Name,
            TransactionType.Expense,
            cancellationToken))
        {
            return Result.Failure<Ulid>(CategoryErrors.UniqueName(request.Name));
        }

        var category = Category.Create(
            userContext.UserId,
            request.Name,
            TransactionType.Expense);

        categoryRepository.Add(category);

        return category.Id;
    }
}
