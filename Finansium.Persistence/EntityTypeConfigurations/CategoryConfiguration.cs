using Finansium.Domain.Categories;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(category => category.Type)
            .HasConversion(type => type.Name, name => CategoryType.FromName(name));
    }
}
