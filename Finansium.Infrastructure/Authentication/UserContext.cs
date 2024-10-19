using Finansium.Application.Abstractions.Authentication;

namespace Finansium.Infrastructure.Authentication;

internal sealed class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public string Username => httpContextAccessor.HttpContext!.User.GetUserName();
    public Ulid UserId => httpContextAccessor.HttpContext!.User.GetUserId();
}
