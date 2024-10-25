namespace Finansium.Application.Transactions.Commands.CreateIncome;

public sealed record CreateIncomeTransactionCommand(
    Ulid CategoryId,
    Ulid AccountId,
    decimal Amount,
    DateTimeOffset Date,
    string? Description) : ICommand<Ulid>;
