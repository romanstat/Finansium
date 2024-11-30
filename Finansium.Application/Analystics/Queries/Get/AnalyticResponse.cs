namespace Finansium.Application.Analystics.Queries.Get;

public sealed record AnalyticResponse(
    Currency Currency,
    decimal TotalBalance,
    decimal TotalIncome,
    decimal TotalExpense,
    decimal TotalOperations)
{
    public IReadOnlyList<CategoryAnalyticsResponse> IncomeCategoryAnalytics { get; set; } = [];
    public IReadOnlyList<CategoryAnalyticsResponse> ExpenseCategoryAnalytics { get; set; } = [];
}
