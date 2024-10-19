using Finansium.Application.Users.Commands.Login;

namespace Finansium.Application.Users.Commands.UpdateToken;

internal sealed class UpdateUserTokenCommandHandler(
    IAuthenticationService authenticationService,
    IRefreshTokenRepository refreshTokenRepository,
    IUserRepository userRepository,
    ITokenProvider tokenProvider) : ICommandHandler<UpdateUserTokenCommand, TokenResponse>
{
    public async Task<Result<TokenResponse>> Handle(
        UpdateUserTokenCommand request,
        CancellationToken cancellationToken)
    {
        var authCookieResult = authenticationService.GetAuthCokookie();

        if (authCookieResult.IsFailure)
        {
            return Result.Failure<TokenResponse>(authCookieResult.Error);
        }

        var authDetails = authCookieResult.Value;

        if (!await refreshTokenRepository.IsValidAsync(
            authDetails.Username, 
            authDetails.RefreshToken, 
            cancellationToken))
        {
            return Result.Failure<TokenResponse>(RefreshTokenErrors.Invalid);
        }

        var user = await userRepository.GetByUsernameAsync(authDetails.Username, cancellationToken);

        if (user is null)
        {
            return Result.Failure<TokenResponse>(UserErrors.NotFound(authDetails.Username));
        }

        var jwtToken = tokenProvider.GenerateJwtToken(user);

        var refreshToken = tokenProvider.GenerateRefreshToken(user);

        await refreshTokenRepository.InsertAsync(refreshToken, cancellationToken);

        var token = new TokenResponse(jwtToken);

        authenticationService.SetAuthInsideCookie(user.Username, refreshToken.Token);

        return token;
    }
}
