namespace Finansium.Application.Accounts.Queries.GetList;

internal sealed class GetAccountListQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext dbContext)
    : IQueryHandler<GetAccountListQuery, IReadOnlyList<AccountResponse>>
{
    public async Task<Result<IReadOnlyList<AccountResponse>>> Handle(
        GetAccountListQuery request, 
        CancellationToken cancellationToken)
    {
        var accounts = await dbContext.Accounts
            .Where(account => account.UserId == userContext.UserId)
            .Select(account => new AccountResponse(
                account.Id,
                account.Name,
                account.Balance.Amount,
                account.Balance.Currency,
                account.CreatedAt,
                account.ModifiedAt))
            .ToListAsync(cancellationToken);

        return accounts;
    }
}
