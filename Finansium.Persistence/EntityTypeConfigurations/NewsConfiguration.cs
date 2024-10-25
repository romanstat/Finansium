using Finansium.Domain.News;

namespace Finansium.Persistence.EntityTypeConfigurations;

internal sealed class NewsConfiguration : IEntityTypeConfiguration<NewsItem>
{
    public void Configure(EntityTypeBuilder<NewsItem> builder)
    {
        builder.Property(news => news.Title)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(news => news.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(news => news.IsOutdated)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(news => news.CreatedAt)
            .HasDefaultValueSql(EntityConfigurations.DateDefaultSql)
            .IsRequired();
    }
}
