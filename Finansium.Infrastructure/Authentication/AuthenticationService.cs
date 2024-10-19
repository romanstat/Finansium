using Finansium.Application.Abstractions.Authentication;
using Finansium.Domain.Users;
using Finansium.Infrastructure.Authentication.OptionSetup;

namespace Finansium.Infrastructure.Authentication;

internal sealed class AuthenticationService(
    IHttpContextAccessor httpContextAccessor,
    IOptionsMonitor<JwtOptions> jwtOptions) : IAuthenticationService
{
    private const string USERNAME = "username";
    private const string REFRESH_TOKEN = "refreshToken";

    public void SetAuthInsideCookie(string username, string refreshToken)
    {
        httpContextAccessor.HttpContext!.Response.Cookies.Append(USERNAME, username,
            new CookieOptions
            {
                MaxAge = TimeSpan.FromMinutes(jwtOptions.CurrentValue.RefreshTokenTimeInMinutes),
            });

        httpContextAccessor.HttpContext!.Response.Cookies.Append(REFRESH_TOKEN, refreshToken,
            new CookieOptions
            {
                MaxAge = TimeSpan.FromMinutes(jwtOptions.CurrentValue.RefreshTokenTimeInMinutes),
            });
    }

    public Result<AuthCookieDetails> GetAuthCokookie()
    {
        var username = httpContextAccessor.HttpContext!.Request.Cookies[USERNAME];
        var refreshToken = httpContextAccessor.HttpContext!.Request.Cookies[REFRESH_TOKEN];

        if (username.IsEmpty() || refreshToken.IsEmpty())
        {
            return Result.Failure<AuthCookieDetails>(RefreshTokenErrors.Invalid);
        }

        var authCookieDetails = new AuthCookieDetails(username!, refreshToken!);

        return authCookieDetails;
    }
}
