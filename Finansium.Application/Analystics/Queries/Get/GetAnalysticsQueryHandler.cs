using System.Linq;

namespace Finansium.Application.Analystics.Queries.Get;

internal sealed class GetAnalysticsQueryHandler(
    IUserContext userContext,
    IUserRepository userRepository,
    IAccountRepository accountRepository,
    IFinansiumDbContext dbContext)
    : IQueryHandler<GetAnalysticsQuery, AnalyticResponse>
{
    private static Dictionary<(Currency From, Currency To), decimal> CurrencyRates => new()
    {
        { (Currency.Byn, Currency.Byn), 1M },
        { (Currency.Byn, Currency.Usd), 3.6M },
        { (Currency.Byn, Currency.Eur), 3.8M },
        { (Currency.Usd, Currency.Byn), 0.3M },
    };

    public async Task<Result<AnalyticResponse>> Handle(
        GetAnalysticsQuery request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(userContext.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<AnalyticResponse>(UserErrors.NotFound(userContext.UserId));
        }

        var userAccounts = await accountRepository.GetByUserIdAsync(user.Id, cancellationToken);

        var totalBalance = userAccounts.Sum(account =>
            account.Balance.Amount * CurrencyRates[(user.Currency, account.Balance.Currency)]);

        var totalTransactionSum = (await dbContext.Transactions
            .Where(transaction => transaction.Account!.UserId == userContext.UserId)
            .Where(transaction =>
                transaction.Date >= request.StartDate && transaction.Date <= request.EndDate)
            .GroupBy(transaction => transaction.Type)
            .ToListAsync(cancellationToken))
            .Select(group => new
            {
                Type = group.Key,
                TotalAmount = group.Sum(transaction =>
                    transaction.Amount.Amount * CurrencyRates[(user.Currency, transaction.Amount.Currency)])
            })
            .ToDictionary(
                key => key.Type,
                value => value.TotalAmount);

        var totalTransactions = await dbContext.Transactions.CountAsync(transaction =>
            transaction.Account!.UserId == userContext.UserId &&
            transaction.Date >= request.StartDate && transaction.Date <= request.EndDate,
            cancellationToken);

        var totalAccountTransfers = await dbContext.AccountTransfers.CountAsync(transaction =>
            transaction.Date >= request.StartDate && transaction.Date <= request.EndDate,
            cancellationToken);

        var incomeCategoryAnalytics = (await dbContext.Transactions
            .Where(transaction =>
                transaction.Date >= request.StartDate && transaction.Date <= request.EndDate &&
                transaction.Type == TransactionType.Income)
            .GroupBy(transaction => transaction.Category!.Name)
            .ToListAsync(cancellationToken))
            .Select(group => new CategoryAnalyticsResponse(
                group.Key,
                group.Sum(transaction =>
                    transaction.Amount.Amount * CurrencyRates[(user.Currency, transaction.Amount.Currency)]),
                group.Count()))
            .OrderByDescending(transaction => transaction.Amount)
            .Take(5)
            .ToList();

        var expenseCategoryAnalytics = (await dbContext.Transactions
            .Where(transaction =>
                transaction.Date >= request.StartDate && transaction.Date <= request.EndDate &&
                transaction.Type == TransactionType.Expense)
            .GroupBy(transaction => transaction.Category!.Name)
            .ToListAsync(cancellationToken))
            .Select(group => new CategoryAnalyticsResponse(
                group.Key,
                group.Sum(transaction =>
                    transaction.Amount.Amount * CurrencyRates[(user.Currency, transaction.Amount.Currency)]),
                group.Count()))
            .OrderByDescending(transaction => transaction.Amount)
            .Take(5)
            .ToList();

        var analyticResponse = new AnalyticResponse(
            user.Currency,
            totalBalance,
            totalTransactionSum[TransactionType.Income],
            totalTransactionSum[TransactionType.Expense],
            totalTransactions + totalAccountTransfers)
        {
            IncomeCategoryAnalytics = incomeCategoryAnalytics,
            ExpenseCategoryAnalytics = expenseCategoryAnalytics
        };

        return analyticResponse;
    }
}
