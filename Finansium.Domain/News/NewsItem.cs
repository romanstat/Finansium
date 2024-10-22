namespace Finansium.Domain.News;

public sealed class NewsItem : Entity
{
    private NewsItem() { }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public bool IsOutDated { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public static NewsItem Create(
        string title,
        string description,
        DateTimeOffset createdAt)
    {
        var news = new NewsItem
        {
            Title = title,
            Description = description,
            IsOutDated = false,
            CreatedAt = createdAt
        };

        return news;
    }
}
