namespace Finansium.Domain.Users;

public sealed class RefreshToken : Entity
{
    private RefreshToken() { }

    public Ulid UserId { get; private set; }

    public User? User { get; private set; }

    public string Token { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime ExpiredAt { get; private set; }

    public static RefreshToken Create(
        Ulid userId,
        string token,
        DateTime createdAt,
        DateTime expiredAt)
    {
        var refreshToken = new RefreshToken
        {
            UserId = userId,
            Token = token,
            CreatedAt = createdAt,
            ExpiredAt = expiredAt
        };

        return refreshToken;
    }
}
