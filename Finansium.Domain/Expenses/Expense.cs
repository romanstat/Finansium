using Finansium.Domain.Accounts;
using Finansium.Domain.Categories;

namespace Finansium.Domain.Expenses;

/// <summary>
/// Расходы
/// </summary>
public sealed class Expense : Entity
{
    public Ulid AccountId { get; private set; }

    public Account? Account { get; private set; }

    public Ulid ExpenseCategoryId { get; private set; }

    public ExpenseCategory? ExpenseCategory { get; private set; }

    public decimal Acount { get; private set; }

    public DateTimeOffset Date { get; private set; }

    public string Description { get; private set; }
}
