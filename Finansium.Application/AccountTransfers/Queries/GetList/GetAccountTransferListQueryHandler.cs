namespace Finansium.Application.AccountTransfers.Queries.GetList;

internal sealed class GetAccountTransferListQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext dbContext)
    : IQueryHandler<GetAccountTransferListQuery, IReadOnlyList<AccountTransferResponse>>
{
    public async Task<Result<IReadOnlyList<AccountTransferResponse>>> Handle(
        GetAccountTransferListQuery request,
        CancellationToken cancellationToken)
    {
        var accountTransfers = await dbContext.AccountTransfers
            .Where(accountTransfer => accountTransfer.UserId == userContext.UserId)
            .Select(accountTransfer => new AccountTransferResponse(
                accountTransfer.Id,
                accountTransfer.SourceAccount!.Name,
                accountTransfer.TargetAccount!.Name,
                accountTransfer.Amount.Amount,
                accountTransfer.CurrencyRate,
                accountTransfer.TransferDate))
            .ToListAsync(cancellationToken);

        return accountTransfers;
    }
}
