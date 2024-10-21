
namespace Finansium.Domain.SavingsGoals;

public static class SavingsGoalErrors
{
    public static Error UniqueName(string name) => Error.Problem(
        $"{nameof(SavingsGoalErrors)}.{nameof(UniqueName)}", $"Накопление с именем '{name}' уже существует");

    public static Error NotFound(Ulid id) => Error.NotFound(
        $"{nameof(SavingsGoalErrors)}.{nameof(NotFound)}", $"Накопление с идентификатором '{id}' не найдено");
}
