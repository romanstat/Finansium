namespace Finansium.Application.Incomes.Commands.Create;

public sealed record CreateExpenseCommand(
    Ulid CategoryId,
    Ulid AccountId,
    decimal Amount,
    string Description) : ICommand<Ulid>;
