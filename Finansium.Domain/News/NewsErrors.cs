namespace Finansium.Domain.News;

public static class NewsErrors
{
    public static Error NotFound(Ulid id) => Error.Problem(
        $"{nameof(NewsErrors)}.{nameof(NotFound)}", $"Новость с идентификатором '{id}' не найдена");
}
