namespace Finansium.Application.Accounts.Commands.Create;

public sealed record CreateAccountCommand(
    string Name,
    decimal Amount,
    string Currency) : ICommand<Ulid>;
