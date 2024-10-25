namespace Finansium.Application.Transactions.Commands.Update;

public sealed record UpdateTransactionCommand(
    Ulid Id,
    Ulid CategoryId,
    Ulid AccountId,
    decimal Amount,
    DateTimeOffset Date) : ICommand<Ulid>;
