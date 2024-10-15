using Finansium.Domain.Counties;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(country => country.ShortName).IsRequired();
    }
}
