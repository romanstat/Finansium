namespace Finansium.Application.Abstractions.Authentication;

public interface ITokenProvider
{
    string GenerateJwtToken(User user);
    RefreshToken GenerateRefreshToken(User user);
}
