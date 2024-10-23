using Finansium.Domain.Accounts;
using Finansium.Domain.Counties;
using Finansium.Domain.SavingsGoals;
using Finansium.Domain.Subscriptions;
using static Finansium.Domain.Subscriptions.SubscriptionType;

namespace Finansium.Domain.Users;

public sealed class User : Entity
{
    private readonly List<Role> _roles = [];
    private readonly List<Subscription> _subscription = [];
    private readonly List<Notification> _notifications = [];
    private readonly List<Account> _accounts = [];
    private readonly List<SavingsGoal> _savingGoals = [];

    public Ulid CountryId { get; private set; }

    public Country? Country { get; private set; }

    public Ulid SubscriptionId { get; private set; }

    public string Name { get; private set; }

    public string Surname { get; private set; }

    public string Username { get; private set; }

    public Email Email { get; private set; }

    public string Password { get; private set; }

    public IReadOnlyCollection<Role> Roles => _roles;

    public IReadOnlyCollection<Subscription> Subscriptions => _subscription;

    public IReadOnlyCollection<Notification> Notifications => _notifications;

    public IReadOnlyCollection<Account> Accounts => _accounts;

    public IReadOnlyCollection<SavingsGoal> SavingsGoals => _savingGoals;

    public static User Create(
        Ulid countryId,
        string name,
        string surname,
        string username,
        Email email,
        string password,
        DateTimeOffset createdAt)
    {
        var user = new User
        {
            CountryId = countryId,
            Name = name,
            Surname = surname,
            Username = username,
            Email = email,
            Password = password,
        };

        user.AddDefaultSubscription(createdAt);

        return user;
    }

    private void AddDefaultSubscription(DateTimeOffset startDate)
    {
        _subscription.Add(Subscription.Create(Id, new FreeSubscription(), startDate));
    }

    public void AddTrialSubscription(DateTimeOffset startDate)
    {
        _subscription.Add(Subscription.Create(Id, new TrialSubscription(), startDate));
    }

    public void UpdatePassword(string newPassword)
    {
        Password = newPassword;
    }

    public void AddNotifications(params Notification[] notifications)
    {
        _notifications.AddRange(notifications);
    }
}
