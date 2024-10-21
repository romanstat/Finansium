namespace Finansium.Application.Accounts.Commands.Update;

public sealed record UpdateAccountCommand(
    Ulid Id,
    string Name,
    decimal Amount,
    string Currency,
    string Status) : ICommand;
