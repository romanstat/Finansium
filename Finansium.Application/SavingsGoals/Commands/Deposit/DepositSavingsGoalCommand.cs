namespace Finansium.Application.SavingsGoals.Commands.Deposit;

public sealed record DepositSavingsGoalCommand(
    Ulid Id,
    Ulid FromAccountId,
    decimal Amount,
    decimal CurrencyRate) : ICommand;
