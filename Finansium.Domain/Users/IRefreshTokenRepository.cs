
namespace Finansium.Domain.Users;

public interface IRefreshTokenRepository
{
    Task InsertAsync(RefreshToken refreshToken, CancellationToken cancellationToken);
    Task<bool> IsValidAsync(string username, string refreshToken, CancellationToken cancellationToken);
}
