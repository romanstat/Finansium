namespace Finansium.Domain.Counties;

public static class CountryErrors
{
    public static Error NotFound(Ulid id) => Error.Problem(
        $"{nameof(CountryErrors)}.{nameof(NotFound)}", $"Страна с идентификатором '{id}' не найдена");
}
