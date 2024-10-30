namespace Finansium.Application.Abstractions.Authentication;

public interface IAuthenticationService
{
    void SetAuthInsideCookie(string username, string refreshToken);
    Result<AuthCookieDetails> GetAuthCookie();
}
