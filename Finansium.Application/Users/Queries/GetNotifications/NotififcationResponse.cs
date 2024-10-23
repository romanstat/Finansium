namespace Finansium.Application.Users.Queries.GetNotifications;

public sealed record NotififcationResponse(
    Ulid Id,
    string Title,
    string Description,
    DateTimeOffset CreatedAt,
    bool IsViewed);
