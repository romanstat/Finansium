namespace Finansium.Application.Incomes.Commands.Update;

public sealed record UpdateExpenseCommand(
    Ulid Id,
    Ulid CategoryId,
    Ulid AccountId,
    decimal Amount) : ICommand<Ulid>;
