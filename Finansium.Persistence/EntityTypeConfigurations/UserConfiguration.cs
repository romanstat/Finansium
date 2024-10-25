using Finansium.Domain.Users;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(user => user.Username).IsUnique();
        builder.HasIndex(user => user.Email).IsUnique();

        builder.Property(user => user.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(user => user.Surname)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(user => user.Patronymic)
            .HasMaxLength(50)
            .IsRequired(false);

        builder.Property(user => user.Username)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(user => user.Email)
            .HasConversion(user => user.Value, value => Email.Create(value).Value)
            .HasMaxLength(254)
            .IsRequired();

        builder.Property(user => user.PasswordHash)
            .HasMaxLength(97)
            .IsRequired();
    }
}
