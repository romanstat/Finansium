namespace Finansium.Application.Notifications.Queries.GetToday;

public sealed record NotififcationResponse(
    Ulid Id,
    string Title,
    string Description,
    DateTimeOffset CreatedAt,
    bool IsViewed);
