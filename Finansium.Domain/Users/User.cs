using Finansium.Domain.Accounts;
using Finansium.Domain.Counties;
using Finansium.Domain.Expenses;
using Finansium.Domain.Incomes;
using Finansium.Domain.SavingsGoals;

namespace Finansium.Domain.Users;

public sealed class User : Entity
{
    private readonly List<Role> _roles = [];
    private readonly List<Account> _accounts = [];
    private readonly List<AutomatedExpense> _automatedExpenses = [];
    private readonly List<AutomatedIncome> _automatedIncomes = [];
    private readonly List<SavingsGoal> _savingTrackers = [];

    public Ulid CountryId { get; private set; }

    public Country? Country { get; private set; }

    public string Name { get; private set; }

    public string Surname { get; private set; }

    public string Username { get; set; }

    public Email Email { get; private set; }

    public string Password { get; private set; }

    public IReadOnlyCollection<Role> Roles => _roles;

    public IReadOnlyCollection<Account> Accounts => _accounts;

    public IReadOnlyCollection<AutomatedExpense> AutomatedExpenses => _automatedExpenses;

    public IReadOnlyCollection<AutomatedIncome> AutomatedIncomes => _automatedIncomes;

    public IReadOnlyCollection<SavingsGoal> SavingTrackers => _savingTrackers;

    public static User Create(
        string name,
        string surname,
        string username,
        Email email,
        string password)
    {
        var user = new User
        {
            Name = name,
            Surname = surname,
            Username = username,
            Email = email,
            Password = password
        };

        return user;
    }
}
