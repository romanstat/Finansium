using Finansium.Domain.Budgets;
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
        var category = await categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            return Result.Failure<Ulid>(CategoryErrors.NotFound(request.CategoryId));
        }

        var budget = Budget.Create(
            BudgetType.FromName(request.BudgetType),
            request.LimitAmount);

        category.AddBudgets(budget);

        return budget.Id;
    }
}
