using Finansium.Domain.Budgets;

namespace Finansium.Application.Categories.Queries.SearchBudget;

public sealed class SearchBudgetQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext dbContext)
    : IQueryHandler<SearchBudgetQuery, IReadOnlyList<BudgetResponse>>
{
    public async Task<Result<IReadOnlyList<BudgetResponse>>> Handle(
        SearchBudgetQuery request,
        CancellationToken cancellationToken)
    {
        var budgetType = BudgetType.FromName(request.Type);

        var budgets = await dbContext.Categories
            .Include(category => category.Budgets)
            .Where(category =>
                category.UserId == userContext.UserId &&
                category.TransactionType == TransactionType.Expense)
            .Select(category => new BudgetResponse(
                category.Budgets.Single(budget => budget.Type == budgetType).Id,
                category.Id,
                category.Name,
                request.Type,
                category.Budgets.Single(budget => budget.Type == budgetType).LimitAmount))
            .ToListAsync(cancellationToken);

        return budgets;
    }
}
