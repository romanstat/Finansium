namespace Finansium.Domain.Accounts;

public sealed record AccountStatus(string Name)
{
    public static readonly AccountStatus Active = new("Active");
    public static readonly AccountStatus Inactive = new("Inactive");
    public static readonly AccountStatus Closed = new("Closed");

    public static readonly IReadOnlyCollection<AccountStatus> All =
    [
        Active,
        Inactive,
        Closed,
    ];

    public static AccountStatus FromName(string name) =>
        All.FirstOrDefault(c => c.Name == name) ??
            throw new ApplicationException("The account status is invalid");
}
