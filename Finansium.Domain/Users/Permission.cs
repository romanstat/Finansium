namespace Finansium.Domain.Users;

public sealed class Permission : Entity
{
    public Ulid RoleId { get; private set; }

    public Role? Role { get; private set; }

    public string Name { get; init; }
}
