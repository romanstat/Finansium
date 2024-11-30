namespace Finansium.Application.Users.Queries.Get;

public record UserResponse(
    Ulid Id,
    string Country,
    Currency Currency,
    string Username,
    string Email,
    string Name,
    string Surname,
    string? Patronymic,
    DateTimeOffset CreatedAt,
    IReadOnlyList<Role> Roles);
