namespace Finansium.Persistence.Repositories;

internal abstract class Repository<TEntity>
    where TEntity : Entity
{
    protected readonly FinansiumDbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    protected Repository(FinansiumDbContext dbContext)
    {
        _dbContext = dbContext;

        _dbSet = _dbContext.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetByIdsAsync(IEnumerable<Ulid> ids, CancellationToken cancellationToken) =>
        await _dbSet.Where(entity => ids.Contains(entity.Id)).ToListAsync(cancellationToken);

    public virtual async Task<TEntity?> GetByIdAsync(Ulid id, CancellationToken cancellationToken) =>
        await _dbSet.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public virtual async Task<TEntity?> GetByIdNoTrackingAsync(Ulid id, CancellationToken cancellationToken) =>
        await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public virtual void Add(TEntity entity) => _dbContext.Add(entity);

    public virtual void Update(TEntity entity) => _dbContext.Update(entity);

    public virtual async Task DeleteAsync(
        Ulid id,
        CancellationToken cancellationToken)
    {
        await DeleteAsync([id], cancellationToken);   
    }

    public virtual async Task DeleteAsync(
        IEnumerable<Ulid> ids,
        CancellationToken cancellationToken)
    {
        if (!ids.Any())
        {
            return;
        }

        await _dbSet
            .Where(x => ids.Contains(x.Id))
            .ExecuteDeleteAsync(cancellationToken);
    }
}
