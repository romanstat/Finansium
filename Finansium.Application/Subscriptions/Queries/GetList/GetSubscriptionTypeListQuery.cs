using Finansium.Domain.Subscriptions;

namespace Finansium.Application.Subscriptions.Queries.GetList;

public sealed record GetSubscriptionTypeListQuery : IQuery<IReadOnlyList<SubscriptionType>>;
