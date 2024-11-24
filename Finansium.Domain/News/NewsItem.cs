namespace Finansium.Domain.News;

public sealed class NewsItem : Entity
{
    public string Title { get; private set; }

    public string Description { get; private set; }

    public bool IsOutdated { get; private set; }

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
            IsOutdated = false,
            CreatedAt = createdAt
        };

        return news;
    }

    public void OutDate()
    {
        IsOutdated = true;
    }

    public void Update(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
