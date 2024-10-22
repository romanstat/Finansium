namespace Finansium.Domain.Categories;

public static class CategoryErrors
{
    public static Error NotFound(Ulid id) => Error.Problem(
        $"{nameof(CategoryErrors)}.{nameof(NotFound)}", $"Категория с идентификатором '{id}' не найдена");

    public static Error UniqueName(string name) => Error.Problem(
        $"{nameof(CategoryErrors)}.{nameof(UniqueName)}", $"Категория с именем '{name}' уже существует");
}
