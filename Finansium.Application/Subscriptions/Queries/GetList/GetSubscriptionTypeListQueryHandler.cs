using Finansium.Domain.Subscriptions;

namespace Finansium.Application.Subscriptions.Queries.GetList;

internal sealed class GetSubscriptionTypeListQueryHandler
    : IQueryHandler<GetSubscriptionTypeListQuery, IReadOnlyList<SubscriptionType>>
{
    public async Task<Result<IReadOnlyList<SubscriptionType>>> Handle(
        GetSubscriptionTypeListQuery request, 
        CancellationToken cancellationToken)
    {
        var subcriptionTypes = SubscriptionType.All.ToList();

        return await Task.FromResult(subcriptionTypes);
    }
}
