namespace Finansium.Domain.Users;

public sealed class RefreshToken : Entity
{
    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public string Token { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public DateTimeOffset ExpiredAt { get; private set; }

    public static RefreshToken Create(
        Ulid userId,
        string token,
        TimeProvider timeProvider,
        DateTimeOffset expiredAt)
    {
        var refreshToken = new RefreshToken
        {
            UserId = userId,
            Token = token,
            CreatedAt = timeProvider.GetUtcNow(),
            ExpiredAt = expiredAt
        };

        return refreshToken;
    }
}
