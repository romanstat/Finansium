namespace Finansium.Application.AccountTransfers.Queries.GetList;

public sealed record GetAccountTransferListQuery : IQuery<IReadOnlyList<AccountTransferResponse>>;
