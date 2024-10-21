using System.Linq.Expressions;
using Finansium.Shared.Extensions;

namespace Finansium.Persistence.Extensions;

public sealed class QueryService : IQueryService
{
    private const string SearchLambdaParameterName = "x";
    private const string ILikeNpgsqlMethodName = "ILike";
    private const string EfFunctionsPropertyName = "Functions";

    public IQueryable<TEntity> SearchByDefault<TEntity>(
        IQueryable<TEntity> source,
        string searchText)
        where TEntity : Entity
    {
        if (searchText.IsEmpty())
        {
            return source;
        }

        var stringColumnNames = GetEntityStringColumnNames<TEntity>();

        if (stringColumnNames.Count == 0)
        {
            return source;
        }

        var searchExpression = BuildSearchExpression<TEntity>(stringColumnNames, searchText.Trim());

        return source.Where(searchExpression);
    }

    private static List<string> GetEntityStringColumnNames<TEntity>()
        where TEntity : Entity
    {
        return ReflectionExtensions.GetPropertiesInfo<TEntity>()
                                   .Where(prop => prop.PropertyType == typeof(string))
                                   .Select(prop => prop.Name)
                                   .ToList();
    }

    private static Expression<Func<TEntity, bool>> BuildSearchExpression<TEntity>(
        IEnumerable<string> stringColumnNames,
        string searchText)
        where TEntity : Entity
    {
        var parameter = Expression.Parameter(typeof(TEntity), SearchLambdaParameterName);
        var searchTextExpression = Expression.Constant($"%{searchText}%");

        Expression? combinedExpression = null;

        foreach (var columnName in stringColumnNames)
        {
            var propertyExpression = BuildPropertySearchExpression(columnName, parameter, searchTextExpression);

            combinedExpression = combinedExpression is null ? propertyExpression :
                Expression.OrElse(combinedExpression, propertyExpression);
        }

        if (combinedExpression is null)
        {
            throw new InvalidOperationException("No valid search expression could be constructed.");
        }

        return Expression.Lambda<Func<TEntity, bool>>(combinedExpression, parameter);
    }

    private static MethodCallExpression BuildPropertySearchExpression(
        string columnName,
        ParameterExpression parameter,
        ConstantExpression searchTextExpression)
    {
        var propertyExpression = Expression.Property(parameter, columnName);

        var iLikeMethod = GetILikeMethod();

        var efFunctions = Expression.Property(null, typeof(EF).GetProperty(EfFunctionsPropertyName)!);

        return Expression.Call(iLikeMethod, efFunctions, propertyExpression, searchTextExpression);
    }

    private static MethodInfo GetILikeMethod()
    {
        return Array.Find(typeof(NpgsqlDbFunctionsExtensions)
            .GetMethods(), method => method.Name == ILikeNpgsqlMethodName && method.GetParameters().Length == 3)
            ?? throw new InvalidOperationException($"Method {ILikeNpgsqlMethodName} not found in {nameof(NpgsqlDbFunctionsExtensions)}.");
    }
}
