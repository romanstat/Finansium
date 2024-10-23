using Finansium.Domain.Budgets;

namespace Finansium.Application.Categories.Commands.DeleteBudget;

internal sealed class DeleteCategoryBudgetCommandHandler(IBudgetRepository budgetRepository)
    : ICommandHandler<DeleteCategoryBudgetCommand>
{
    public async Task<Result> Handle(
        DeleteCategoryBudgetCommand request, 
        CancellationToken cancellationToken)
    {
        await budgetRepository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
