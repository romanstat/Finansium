using Finansium.Domain.Categories;

namespace Finansium.Application.Categories.Commands.CreateBudget;

internal sealed class CreateCategoryBudgetCommandHandler(
    ICategoryRepository categoryRepository)
    : ICommandHandler<CreateCategoryBudgetCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        CreateCategoryBudgetCommand request, 
        CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdWithBudgetsAsync(
            request.CategoryId, 
            cancellationToken);

        if (category is null)
        {
            return Result.Failure<Ulid>(CategoryErrors.NotFound(request.CategoryId));
        }

        var budget = category.Budgets.Single(b => b.Id == request.Id);

        budget.ChangeAmount(request.LimitAmount);

        return budget.Id;
    }
}
