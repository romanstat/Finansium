namespace Finansium.Application.SavingsGoals.Queries.GetList;

public sealed record GetSavingsGoalListQuery : IQuery<IReadOnlyList<SavingsGoalResponse>>;
