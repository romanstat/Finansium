namespace Finansium.Application.AccountTransfers.Queries.GetList;

public sealed record AccountTransferResponse(
    Ulid Id,
    string SourceAccount,
    string TargetAccount,
    decimal Amount,
    string SourceCurrency,
    string TargetCurrency,
    decimal CurrencyRate,
    DateTimeOffset Date);
