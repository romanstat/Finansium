using Finansium.Domain.Budgets;

namespace Finansium.Application.Categories.Commands.UpdateBudget;

internal sealed class UpdateCategoryBudgetCommandHandler(
    IBudgetRepository budgetRepository)
    : ICommandHandler<UpdateCategoryBudgetCommand>
{
    public async Task<Result> Handle(
        UpdateCategoryBudgetCommand request,
        CancellationToken cancellationToken)
    {
        var budgets = await budgetRepository.GetByIdsAsync(
            request.Budgets.Select(budget => budget.Id),
            cancellationToken);

        foreach (var budget in budgets)
        {
            var newLimitAmount = request.Budgets.Single(b => b.Id == budget.Id).LimitAmount;

            budget.ChangeAmount(newLimitAmount);
        }

        return Result.Success();
    }
}
