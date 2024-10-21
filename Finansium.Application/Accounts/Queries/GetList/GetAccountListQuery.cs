namespace Finansium.Application.Accounts.Queries.GetList;

public sealed record GetAccountListQuery : IQuery<IReadOnlyList<AccountResponse>>;
