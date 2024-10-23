namespace Finansium.Application.Expenses.Commands.Update;

public sealed record UpdateExpenseCommand(
    Ulid Id,
    Ulid CategoryId,
    Ulid AccountId,
    decimal Amount,
    DateTimeOffset Date) : ICommand<Ulid>;
