namespace Finansium.Application.Users.Commands.Register;

public sealed record RegisterUserCommand(
    Ulid CountryId,
    string Name,
    string Surname,
    string Email,
    string Username,
    string Password) : ICommand;
