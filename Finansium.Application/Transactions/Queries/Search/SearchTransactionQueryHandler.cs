namespace Finansium.Application.Transactions.Queries.Search;

internal sealed class SearchTransactionQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext dbContext)
    : IQueryHandler<SearchTransactionQuery, IReadOnlyList<TransactionResponse>>
{
    public async Task<Result<IReadOnlyList<TransactionResponse>>> Handle(
        SearchTransactionQuery request,
        CancellationToken cancellationToken)
    {
        var transactions = await dbContext.Transactions
            .Where(transaction =>
                transaction.Account!.UserId == userContext.UserId &&
                transaction.Type == TransactionType.FromName(request.Type))
            .Select(expense => new TransactionResponse(
                expense.Id,
                expense.Category!.Name,
                expense.Account!.Name,
                expense.Amount.Amount,
                expense.Amount.Currency,
                expense.Date,
                expense.Description))
            .ToListAsync(cancellationToken);

        return transactions;
    }
}
