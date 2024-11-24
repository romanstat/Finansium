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
        var categoryType = TransactionType.FromName(request.Type);

        var categories = await dbContext.Categories
            .Where(category => 
                category.UserId == userContext.UserId &&
                category.TransactionType == categoryType)
            .Select(category => new CategoryResponse(
                category.Id,
                category.Name,
                category.TransactionType.Name))
            .ToListAsync(cancellationToken);

        return categories;
    }
}
