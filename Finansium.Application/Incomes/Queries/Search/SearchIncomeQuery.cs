namespace Finansium.Application.Incomes.Queries.Search;

public sealed record SearchIncomeQuery : IQuery<IReadOnlyList<IncomeResponse>>;
