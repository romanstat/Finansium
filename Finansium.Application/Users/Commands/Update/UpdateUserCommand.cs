namespace Finansium.Application.Users.Commands.Update;

public sealed record UpdateUserCommand(
    Ulid Id, 
    string Name, 
    string Surname,
    string Patronymic) : ICommand;
