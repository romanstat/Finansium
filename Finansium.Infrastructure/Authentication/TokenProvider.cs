using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Finansium.Application.Abstractions.Authentication;
using Finansium.Domain.Users;
using Finansium.Infrastructure.Authentication.OptionSetup;
using Microsoft.IdentityModel.Tokens;

namespace Finansium.Infrastructure.Authentication;

internal sealed class TokenProvider(
    TimeProvider timeProvider,
    IOptions<JwtOptions> jwtOptios) : ITokenProvider
{
    public string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Sid, user.Id.ToString()),
            new(ClaimTypes.NameIdentifier, user.Username),
            new(ClaimTypes.Email, user.Email.Value),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Surname, user.Surname),
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOptios.Value.Key)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            jwtOptios.Value.Issuer,
            jwtOptios.Value.Audience,
            claims,
            null,
            timeProvider.GetUtcNow().UtcDateTime.AddMinutes(jwtOptios.Value.AccessTokenTimeInMinutes),
            signingCredentials);

        var tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return tokenValue;
    }

    public RefreshToken GenerateRefreshToken(User user)
    {
        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        var refreshTokenResult = RefreshToken.Create(
            user.Id,
            token,
            timeProvider.GetUtcNow(),
            timeProvider.GetUtcNow().AddMinutes(jwtOptios.Value.RefreshTokenTimeInMinutes));

        return refreshTokenResult;
    }
}
