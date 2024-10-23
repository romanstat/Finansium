namespace Finansium.Application.Incomes.Commands.Create;

public sealed record CreateIncomeCommand(
    Ulid CategoryId,
    Ulid AccountId,
    decimal Amount) : ICommand<Ulid>;
