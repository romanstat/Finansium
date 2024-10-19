﻿using Finansium.Domain.Users;

namespace Finansium.Persistence.Repositories;

internal sealed class UserRepository(FinansiumDbContext finansiumDbContext)
    : Repository<User>(finansiumDbContext), IUserRepository
{
    public async Task<User?> GetByUsernameAndPasswordNoTrackingAsync(
        string username, 
        string password, 
        CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().SingleOrDefaultAsync(user => 
            user.Username == username && 
            user.Password == password,
            cancellationToken);

    public async Task<User?> GetByUsernameAsync(
        string username, 
        CancellationToken cancellationToken) =>
            await _dbSet.SingleOrDefaultAsync(user => user.Username == username, cancellationToken);

    public async Task<User?> GetByUsernameNoTrackingAsync(
        string username, 
        CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().SingleOrDefaultAsync(user => user.Username == username, cancellationToken);

    public async Task<bool> IsEmailUniqueAsync(
        Email email,
        CancellationToken cancellationToken) =>
            !await _dbSet.AnyAsync(user => user.Email == email, cancellationToken);
}