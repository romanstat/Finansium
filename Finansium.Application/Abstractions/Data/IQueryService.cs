namespace Finansium.Application.Abstractions.Data;

public interface IQueryService
{
    IQueryable<TEntity> SearchByDefault<TEntity>(IQueryable<TEntity> source, string searchText) where TEntity : Entity;
}
