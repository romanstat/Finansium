namespace Finansium.Application.Accounts.Commands.Transfer;

public sealed record TransferAccountCommand(
    Ulid SourceAccountId,
    Ulid TargetAccountId,
    decimal Amount,
    decimal CurrencyRate) : ICommand;
