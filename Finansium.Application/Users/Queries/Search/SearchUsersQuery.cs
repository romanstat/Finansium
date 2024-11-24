using Finansium.Application.Users.Queries.Get;

namespace Finansium.Application.Users.Queries.Search;

public sealed record SearchUsersQuery(string SearchTerm): IQuery<IReadOnlyList<UserResponse>>;
