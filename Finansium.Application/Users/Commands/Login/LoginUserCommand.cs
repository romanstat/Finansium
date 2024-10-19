namespace Finansium.Application.Users.Commands.Login;

public sealed record LoginUserCommand(
    string Username,
    string Password) : ICommand<TokenResponse>;
