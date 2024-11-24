namespace Finansium.Application.Accounts.Commands.Create;

public sealed record CreateAccountCommand(
    string Name,
    decimal Balance,
    string Currency) : ICommand<Ulid>;
