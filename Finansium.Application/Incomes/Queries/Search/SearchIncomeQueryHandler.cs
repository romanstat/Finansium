namespace Finansium.Application.Incomes.Queries.Search;

internal sealed class SearchIncomeQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext dbContext)
    : IQueryHandler<SearchIncomeQuery, IReadOnlyList<IncomeResponse>>
{
    public async Task<Result<IReadOnlyList<IncomeResponse>>> Handle(
        SearchIncomeQuery request, 
        CancellationToken cancellationToken)
    {
        var incomes = await dbContext.Expenses
            .Where(income => income.Account!.UserId == userContext.UserId)
            .Select(income => new IncomeResponse(
                income.Id,
                income.Category!.Name,
                income.Account!.Name,
                income.Amount.Amount,
                income.Amount.Currency,
                income.Date))
            .ToListAsync(cancellationToken);

        return incomes;
    }
}
