namespace Finansium.Application.Transactions.Commands.Delete;

public sealed record DeleteTransactionCommand(Ulid Id) : ICommand;
