using Finansium.Application.Users.Queries.Get;

namespace Finansium.Application.Users.Queries.Search;

internal sealed class SearchUsersQueryHandler(
    IFinansiumDbContext dbContext,
    IQueryService queryService)
    : IQueryHandler<SearchUsersQuery, IReadOnlyList<UserResponse>>
{
    public async Task<Result<IReadOnlyList<UserResponse>>> Handle(
        SearchUsersQuery request,
        CancellationToken cancellationToken)
    {
        var usersQuery = dbContext.Users.AsQueryable();

        usersQuery = queryService.SearchByDefault(usersQuery, request.SearchTerm);

        var users = await usersQuery
            .Select(user => new UserResponse(
                user.Id,
                user.Country!.ShortName,
                user.Username,
                user.Email.Value,
                user.Name,
                user.Surname,
                user.Patronymic,
                user.CreatedeAt,
                user.Roles.ToList()))
            .ToListAsync(cancellationToken);

        return users;
    }
}
