namespace Finansium.Application.RecurringTransactions.Queries.Search;

internal sealed class SearchRecurringTransactionsQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext dbContext)
    : IQueryHandler<SearchRecurringTransactionsQuery, IReadOnlyList<RecurringTransactionResponse>>
{
    public async Task<Result<IReadOnlyList<RecurringTransactionResponse>>> Handle(
        SearchRecurringTransactionsQuery request,
        CancellationToken cancellationToken)
    {
        var recurringTransactions = await dbContext.RecurringTransactions
            .Include(recurringTransaction => recurringTransaction.Account)
            .Where(recurringTransaction =>
                recurringTransaction.Account!.UserId == userContext.UserId &&
                recurringTransaction.Type == TransactionType.FromName(request.Type))
            .Select(recurringTransaction => new RecurringTransactionResponse(
                recurringTransaction.Id,
                recurringTransaction.Account!.Name,
                recurringTransaction.Amount,
                recurringTransaction.Type.Name,
                recurringTransaction.Interval,
                recurringTransaction.StartDate,
                recurringTransaction.EndDate,
                recurringTransaction.NextPaymentDate,
                recurringTransaction.Description))
            .ToListAsync(cancellationToken);

        return recurringTransactions;
    }
}
