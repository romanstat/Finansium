namespace Finansium.Domain.Transactions;

public static class TransactionErrors
{
    public static Error NotFound(Ulid id) => Error.Problem(
        $"{nameof(TransactionErrors)}.{nameof(NotFound)}", $"Транзакция с идентификатором '{id}' не найдена");
}
