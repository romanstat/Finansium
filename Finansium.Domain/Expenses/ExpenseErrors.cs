namespace Finansium.Domain.Expenses;

public static class ExpenseErrors
{
    public static Error NotFound(Ulid id) => Error.Problem(
        $"{nameof(ExpenseErrors)}.{nameof(NotFound)}", $"Трата с идентификатором '{id}' не найдена");
}
