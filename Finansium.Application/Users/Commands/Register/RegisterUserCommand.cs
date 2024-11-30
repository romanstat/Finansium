namespace Finansium.Application.Users.Commands.Register;

public sealed record RegisterUserCommand(
    Ulid CountryId,
    string Currency,
    string Name,
    string Surname,
    string Patronymic,
    string Email,
    string Username,
    string Password,
    string RetryPassword) : ICommand;
