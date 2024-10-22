using Finansium.Domain.Subscriptions;

namespace Finansium.Application.Users.Queries.Get;

public record UserResponse(
    Ulid Id,
    string Username,
    string Email,
    string Name,
    string Surname,
    SubscriptionType Subscription);
