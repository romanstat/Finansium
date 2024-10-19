using Finansium.Application.Users.Commands.Login;

namespace Finansium.Application.Users.Commands.UpdatePassword;

internal sealed class UpdateUserPasswordCommandHandler(
    IUserContext userContext,
    IUserRepository userRepository) : ICommandHandler<UpdateUserPasswordCommand>
{
    public async Task<Result> Handle(
        UpdateUserPasswordCommand request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsernameNoTrackingAsync(
            userContext.Username,
            cancellationToken);

        if (user is null)
        {
            return Result.Failure<TokenResponse>(UserErrors.InvalidCredentials);
        }

        user.UpdatePassword(request.NewPassword);

        return Result.Success();
    }
}
