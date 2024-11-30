namespace Finansium.Application.Analystics.Queries.Get;

public sealed record GetAnalysticsQuery(
    DateTimeOffset StartDate,
    DateTimeOffset EndDate) : IQuery<AnalyticResponse>;
