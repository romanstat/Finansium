namespace Finansium.Application.Expenses.Commands.Create;

public sealed record CreateExpenseCommand(
    Ulid CategoryId,
    Ulid AccountId,
    decimal Amount,
    string Description,
    DateTimeOffset Date) : ICommand<Ulid>;
