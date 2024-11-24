namespace Finansium.Domain.Users;

public static class NotificationErrors
{
    public static Error NotFound(Ulid id) => Error.Problem(
        $"{nameof(NotificationErrors)}.{nameof(NotFound)}", 
        $"Уведомление с идентификатором '{id}' не найдено");
}
