namespace Finansium.Domain.RecurringTransactions;

public static class RecurringTransactionErrors
{
    public static Error NotFound(Ulid id) => Error.NotFound(
        $"{nameof(RecurringTransactionErrors)}.{nameof(NotFound)}", 
        $"Повторяющаяся  транзакция с идентификатором '{id}' не найдена");
}
