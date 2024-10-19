namespace Finansium.Application.Users.Commands.UpdatePassword;

public sealed record UpdateUserPasswordCommand(
    string OldPassword,
    string NewPassword,
    string RetryPassword) : ICommand;
