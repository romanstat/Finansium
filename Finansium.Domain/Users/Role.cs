namespace Finansium.Domain.Users;

public sealed class Role
{
    public static readonly Role User = new(1, "User");
    public static readonly Role Admin = new(2, "Admin");

    private Role(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public long Id { get; init; }

    public string Name { get; init; }

    public ICollection<User> Users { get; init; } = [];

    public ICollection<Permission> Permissions { get; init; } = [];
}
