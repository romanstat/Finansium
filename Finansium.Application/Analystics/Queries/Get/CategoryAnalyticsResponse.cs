namespace Finansium.Application.Analystics.Queries.Get;

public sealed record CategoryAnalyticsResponse(
    string Name,
    decimal Amount,
    long TotalOperations);
