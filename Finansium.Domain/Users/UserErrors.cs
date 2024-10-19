namespace Finansium.Domain.Users;

public static class UserErrors
{
    public static Error NotFound(string username) => Error.Problem(
        $"{nameof(UserErrors)}.{nameof(NotFound)}", $"Пользователь '{username}' не найден");

    public static readonly Error InvalidCredentials = Error.Problem(
        $"{nameof(UserErrors)}.{nameof(InvalidCredentials)}", "Неверные данные для входа");
}
