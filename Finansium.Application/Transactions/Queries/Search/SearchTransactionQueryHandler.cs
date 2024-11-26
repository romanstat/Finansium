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
                transaction.Account!.UserId == userContext.UserId)
            .Select(transaction => new TransactionResponse(
                transaction.Id,
                transaction.Type.Name,
                transaction.Category!.Name,
                transaction.Account!.Name,
                transaction.Amount.Amount,
                transaction.Amount.Currency,
                transaction.Date,
                transaction.Description))
            .ToListAsync(cancellationToken);

        return transactions;
    }
}
