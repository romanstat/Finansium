namespace Finansium.Domain.News;

public sealed class News : Entity
{
    private News() { }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public bool IsOutDated { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public static News Create(
        string title,
        string description,
        TimeProvider timeProvider)
    {
        var news = new News
        {
            Title = title,
            Description = description,
            IsOutDated = false,
            CreatedAt = timeProvider.GetUtcNow()
        };

        return news;
    }
}
