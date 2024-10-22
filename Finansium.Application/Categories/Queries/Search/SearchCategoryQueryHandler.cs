using Finansium.Domain.Categories;

namespace Finansium.Application.Categories.Queries.Search;

internal sealed class SearchCategoryQueryHandler(
    IUserContext userContext,
    IFinansiumDbContext dbContext)
    : IQueryHandler<SearchCategoryQuery, IReadOnlyList<CategoryResponse>>
{
    public async Task<Result<IReadOnlyList<CategoryResponse>>> Handle(
        SearchCategoryQuery request, 
        CancellationToken cancellationToken)
    {
        var categoryType = CategoryType.FromName(request.Type);

        var categories = await dbContext.Categories
            .Where(account => 
                account.UserId == userContext.UserId &&
                account.Type == categoryType)
            .Select(account => new CategoryResponse(
                account.Id,
                account.Name))
            .ToListAsync(cancellationToken);

        return categories;
    }
}
