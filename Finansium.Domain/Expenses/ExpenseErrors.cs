namespace Finansium.Domain.Expenses;

public static class ExprenseErrors
{
    public static Error NotFound(Ulid id) => Error.Problem(
        $"{nameof(ExprenseErrors)}.{nameof(NotFound)}", $"Трата с идентификатором '{id}' не найдена");
}
