namespace Finansium.Domain.Incomes;

public static class IncomeErrors
{
    public static Error NotFound(Ulid id) => Error.Problem(
        $"{nameof(IncomeErrors)}.{nameof(NotFound)}", $"Доход с идентификатором '{id}' не найден");
}
