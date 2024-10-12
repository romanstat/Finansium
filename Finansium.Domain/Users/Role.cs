namespace Finansium.Domain.Users;

public sealed class Role : Entity
{
    public string Name { get; init; }

    public ICollection<User> Users { get; init; } = [];

    public ICollection<Permission> Permissions { get; init; } = [];
}
