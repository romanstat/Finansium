namespace Finansium.Application.RecurringTransactions.Queries.GetList;

internal sealed class GetRecurringTransactionsQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext dbContext)
    : IQueryHandler<GetRecurringTransactionsQuery, IReadOnlyList<RecurringTransactionResponse>>
{
    public async Task<Result<IReadOnlyList<RecurringTransactionResponse>>> Handle(
        GetRecurringTransactionsQuery request, 
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
