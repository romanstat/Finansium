namespace Finansium.Application.AccountTransfers.Queries.GetList;

public sealed record AccountTransferResponse(
    Ulid Id,
    string SourceAccount,
    string TargetAccount,
    decimal Amount,
    Currency SourceCurrency,
    Currency TargetCurrency,
    decimal CurrencyRate,
    DateTimeOffset Date);
