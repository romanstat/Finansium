namespace Finansium.Application.Categories.Queries.Search;

public sealed record SearchCategoryQuery(string Type) : IQuery<IReadOnlyList<CategoryResponse>>;
