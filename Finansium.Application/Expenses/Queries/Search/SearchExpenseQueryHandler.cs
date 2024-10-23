namespace Finansium.Application.Expenses.Queries.Search;

internal sealed class SearchExpenseQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext dbContext)
    : IQueryHandler<SearchExpenseQuery, IReadOnlyList<ExpenseResponse>>
{
    public async Task<Result<IReadOnlyList<ExpenseResponse>>> Handle(
        SearchExpenseQuery request,
        CancellationToken cancellationToken)
    {
        var expenses = await dbContext.Expenses
            .Where(expense => expense.Account!.UserId == userContext.UserId)
            .Select(expense => new ExpenseResponse(
                expense.Id,
                expense.Category!.Name,
                expense.Account!.Name,
                expense.Amount.Amount,
                expense.Amount.Currency,
                expense.Description,
                expense.Date))
            .ToListAsync(cancellationToken);

        return expenses;
    }
}
