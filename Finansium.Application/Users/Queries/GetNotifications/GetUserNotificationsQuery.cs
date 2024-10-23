namespace Finansium.Application.Users.Queries.GetNotifications;

public sealed record GetUserNotificationsQuery : IQuery<IReadOnlyList<NotififcationResponse>>;
