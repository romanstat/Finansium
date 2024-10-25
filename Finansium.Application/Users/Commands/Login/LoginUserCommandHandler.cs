namespace Finansium.Application.Users.Commands.Login;

internal sealed class LoginUserCommandHandler(
    IUserRepository userRepository,
    IAuthenticationService authenticationService,
    ITokenProvider tokenProvider,
    IRefreshTokenRepository refreshTokenRepository,
    IPasswordHasher passwordHasher) : ICommandHandler<LoginUserCommand, TokenResponse>
{
    public async Task<Result<TokenResponse>> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsernameNoTrackingAsync(
            request.Username,
            cancellationToken);

        if (user is null || !passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
        {
            return Result.Failure<TokenResponse>(UserErrors.InvalidCredentials);
        }

        var jwtToken = tokenProvider.GenerateJwtToken(user);

        var refreshToken = tokenProvider.GenerateRefreshToken(user);

        await refreshTokenRepository.InsertAsync(refreshToken, cancellationToken);

        var token = new TokenResponse(jwtToken);

        authenticationService.SetAuthInsideCookie(user.Username, refreshToken.Token);

        return token;
    }
}
