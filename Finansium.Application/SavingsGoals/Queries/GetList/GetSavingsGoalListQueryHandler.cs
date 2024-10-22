﻿namespace Finansium.Application.SavingsGoals.Queries.GetList;

internal sealed class GetSavingsGoalListQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext dbContext)
    : IQueryHandler<GetSavingsGoalListQuery, IReadOnlyList<SavingsGoalResponse>>
{
    public async Task<Result<IReadOnlyList<SavingsGoalResponse>>> Handle(
        GetSavingsGoalListQuery request,
        CancellationToken cancellationToken)
    {
        var savingsGoal = await dbContext.SavingsGoals
            .Where(savingsGoal => savingsGoal.UserId == userContext.UserId)
            .Select(savingsGoal => new SavingsGoalResponse(
                savingsGoal.Id,
                savingsGoal.Name,
                savingsGoal.Account!.Balance.Amount,
                savingsGoal.TargetAmount.Amount,
                savingsGoal.Account.Balance.Currency.Code,
                savingsGoal.Note,
                savingsGoal.StartDate,
                savingsGoal.EndDate,
                savingsGoal.IsCompleted))
            .ToListAsync(cancellationToken);

        return savingsGoal;
    }
}