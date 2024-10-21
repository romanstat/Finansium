namespace Finansium.Application.AccountTransfers.Queries.GetList;

public sealed record AccountTransferResponse(
    Ulid Id,
    string SourceAccountName,
    string TargetAccountName,
    decimal Amount,
    decimal CurrencyRate,
    DateTimeOffset TransfeDate);
