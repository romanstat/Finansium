using Finansium.Domain.Budgets;

namespace Finansium.Domain.Categories;

public static class CategoryErrors
{
    public static Error BudgetAlreadyExists(BudgetType budgetType) => Error.Problem(
        $"{nameof(CategoryErrors)}.{nameof(BudgetAlreadyExists)}", $"Бюджет с типом '{budgetType.Name}' уже существует");

    public static Error NotFound(Ulid id) => Error.Problem(
        $"{nameof(CategoryErrors)}.{nameof(NotFound)}", $"Категория с идентификатором '{id}' не найдена");

    public static Error UniqueName(string name) => Error.Problem(
        $"{nameof(CategoryErrors)}.{nameof(UniqueName)}", $"Категория с именем '{name}' уже существует");
}
