using Finansium.Domain.Users;

namespace Finansium.Persistence.Repositories;

internal sealed class RefreshTokenRepository(
    FinansiumDbContext dbContext,
    TimeProvider timeProvider)
    : Repository<RefreshToken>(dbContext), IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetByUsernameAsync(
        string username,
        CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(
            refreshToken => refreshToken.User!.Username == username,
            cancellationToken);
    }

    public async Task InsertAsync(
        RefreshToken refreshToken,
        CancellationToken cancellationToken)
    {
        await DeleteByUserIdAsync(refreshToken.UserId, cancellationToken);

        Add(refreshToken);
    }

    public async Task DeleteByUserIdAsync(
        Ulid userId,
        CancellationToken cancellationToken)
    {
        await _dbSet
            .Where(refreshToken => refreshToken.UserId == userId)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<bool> IsValidAsync(
        string username,
        string refreshToken,
        CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(token => 
            token.User!.Username == username &&
            token.Token == refreshToken &&
            token.ExpiredAt >= timeProvider.GetUtcNow(),
            cancellationToken);
    }
}
