namespace Finansium.Domain.Users;

public static class RefreshTokenErrors
{
    public static readonly Error Invalid = Error.Problem(
        $"{nameof(RefreshTokenErrors)}.{nameof(Invalid)}", "Ошибка недействительный токен обновления");
}
