namespace Finansium.Application.Users.Commands.Login;

public sealed record UserDetails(
    string Username,
    string Email,
    string Name,
    string Surname);
