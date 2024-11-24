using Finansium.Application.Notifications.Queries.GetToday;

namespace Finansium.Application.Notifications.Queries.GetOlder;

public sealed record GetOlderNotificationsQuery : IQuery<IReadOnlyList<NotififcationResponse>>;
