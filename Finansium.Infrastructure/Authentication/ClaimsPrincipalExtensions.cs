using System.Security.Claims;

namespace Finansium.Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions
{
    internal static string GetUserName(this ClaimsPrincipal? principal)
    {
        var userName = principal?.FindFirstValue(ClaimTypes.NameIdentifier);

        return userName ?? throw new ApplicationException("Пользователь не доступен");
    }

    internal static Ulid GetUserId(this ClaimsPrincipal? principal)
    {
        var userId = principal?.FindFirstValue(ClaimTypes.Sid);

        if (userId is null)
        {
            throw new ApplicationException("Пользователь не доступен");
        }

        return Ulid.Parse(userId);
    }
}
