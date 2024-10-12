using Finansium.Domain.Users;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.Property(refreshToken => refreshToken.Token)
            .HasMaxLength(88)
            .IsRequired();

        builder.Property(refreshToken => refreshToken.CreatedAt)
            .HasDefaultValue(TimeProvider.System.GetUtcNow())
            .IsRequired();

        builder.Property(refreshToken => refreshToken.ExpiredAt).IsRequired();
    }
}
