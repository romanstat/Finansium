namespace Finansium.Application.Users.Queries.Get;

internal sealed class GetUserQueryHandler(
    TimeProvider timeProvider,
    IUserContext userContext,
    IFinansiumDbContext dbContext)
    : IQueryHandler<GetUserQuery, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(
        GetUserQuery request,
        CancellationToken cancellationToken)
    {
        var userResponse = await dbContext.Users
            .Where(user => user.Username == userContext.Username)
            .Select(user => new UserResponse(
                user.Id,
                user.Username,
                user.Email.Value,
                user.Name,
                user.Surname,
                user.Subscriptions.Single(subscrtion => 
                    subscrtion.UserId == userContext.UserId &&
                    subscrtion.ExpiredAt >= timeProvider.GetUtcNow()).Type.Name))
            .SingleOrDefaultAsync(cancellationToken);

        if (userResponse is null)
        {
            return Result.Failure<UserResponse>(UserErrors.NotFound(userContext.Username));
        }

        return userResponse;
    }
}
