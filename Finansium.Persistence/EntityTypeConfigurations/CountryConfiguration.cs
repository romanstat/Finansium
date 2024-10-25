using Finansium.Domain.Counties;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasIndex(country => country.ShortName).IsUnique();
        builder.HasIndex(country => country.Alpha2Code).IsUnique();
        builder.HasIndex(country => country.Alpha3Code).IsUnique();
        builder.HasIndex(country => country.NumericCode).IsUnique();

        builder.Property(country => country.ShortName)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(country => country.FullName)
            .HasMaxLength(60)
            .IsRequired(false);

        builder.Property(country => country.Alpha2Code)
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(country => country.Alpha3Code)
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(country => country.NumericCode).IsRequired();
    }
}
