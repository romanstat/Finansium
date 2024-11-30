using Finansium.Domain.Accounts;
using Finansium.Domain.Counties;
using Finansium.Domain.SavingsGoals;

namespace Finansium.Domain.Users;

public sealed class User : Entity
{
    private readonly List<Role> _roles = [];
    private readonly List<Notification> _notifications = [];
    private readonly List<Account> _accounts = [];
    private readonly List<SavingsGoal> _savingGoals = [];

    public Ulid CountryId { get; private set; }

    public Country? Country { get; private set; }

    public Currency Currency { get; private set; }

    public string Name { get; private set; }

    public string Surname { get; private set; }

    public string? Patronymic { get; private set; }

    public string Username { get; private set; }

    public Email Email { get; private set; }

    public string PasswordHash { get; private set; }

    public DateTimeOffset CreatedeAt { get; private set; }

    public IReadOnlyCollection<Role> Roles => _roles;

    public IReadOnlyCollection<Notification> Notifications => _notifications;

    public IReadOnlyCollection<Account> Accounts => _accounts;

    public IReadOnlyCollection<SavingsGoal> SavingsGoals => _savingGoals;

    public static User Create(
        Ulid countryId,
        Currency currency,
        string name,
        string surname,
        string patronymic,
        string username,
        Email email,
        string passwordHash,
        DateTimeOffset createdAt)
    {
        var user = new User
        {
            CountryId = countryId,
            Currency = currency,
            Name = name,
            Surname = surname,
            Patronymic = patronymic,
            Username = username,
            Email = email,
            PasswordHash = passwordHash,
            CreatedeAt = createdAt
        };

        user._roles.Add(Role.User);

        return user;
    }

    public void UpdatePassword(string newPassword)
    {
        PasswordHash = newPassword;
    }

    public void AddNotifications(params Notification[] notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void Update(
        string name,
        string surname,
        string patronymic)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
    }
}
