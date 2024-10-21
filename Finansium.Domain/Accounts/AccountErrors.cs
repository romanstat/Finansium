namespace Finansium.Domain.Accounts;

public static class AccountErrors
{
    public static readonly Error InvalidAmount = Error.Problem(
        $"{nameof(AccountErrors)}.{nameof(InvalidAmount)}", "Сумма депозита должна быть больше нуля");

    public static readonly Error InsufficientBalance = Error.Problem(
        $"{nameof(AccountErrors)}.{nameof(InsufficientBalance)}", "Недостаточный баланс");

    public static readonly Error DifferentCurrency = Error.Problem(
        $"{nameof(AccountErrors)}.{nameof(DifferentCurrency)}", "Разные валюты");

    public static readonly Error TransferAccountConflict = Error.Problem(
        $"{nameof(AccountErrors)}.{nameof(TransferAccountConflict)}", "Невозможно перевести на тот же счёт");

    public static Error IsExists(string name) => Error.Problem(
        $"{nameof(AccountErrors)}.{nameof(IsExists)}", $"Счёт с именем '{name}' уже существует");

    public static Error NotFound(Ulid id) => Error.Problem(
        $"{nameof(AccountErrors)}.{nameof(NotFound)}", $"Счёт с идентификатором '{id}' не найден");
}
