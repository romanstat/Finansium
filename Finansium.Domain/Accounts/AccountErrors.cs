namespace Finansium.Domain.Accounts;

public static class AccountErrors
{
    public static readonly Error InvalidAmount = Error.Problem(
        $"{nameof(AccountErrors)}.{nameof(InvalidAmount)}", "Сумма депозита должна быть больше нуля");

    public static readonly Error InsufficientBalance = Error.Problem(
        $"{nameof(AccountErrors)}.{nameof(InsufficientBalance)}", "Недостаточный баланс");
}
