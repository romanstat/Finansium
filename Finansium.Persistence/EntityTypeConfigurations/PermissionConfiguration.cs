using Finansium.Domain.Users;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.Property(permission => permission.Name)
           .HasMaxLength(50)
           .IsRequired();
    }
}
