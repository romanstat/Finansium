using Finansium.Domain.Users;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasIndex(role => role.Name).IsUnique();

        builder.Property(role => role.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}
