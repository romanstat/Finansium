namespace Finansium.Application.Transactions.Commands.CreateExpense;

public sealed record CreateExpenseTransactionCommand(
    Ulid CategoryId,
    Ulid AccountId,
    decimal Amount,
    string Description,
    DateTimeOffset Date) : ICommand<Ulid>;
