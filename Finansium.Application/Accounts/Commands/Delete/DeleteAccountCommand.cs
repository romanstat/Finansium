namespace Finansium.Application.Accounts.Commands.Delete;

public sealed record DeleteAccountCommand(Ulid Id) : ICommand;
