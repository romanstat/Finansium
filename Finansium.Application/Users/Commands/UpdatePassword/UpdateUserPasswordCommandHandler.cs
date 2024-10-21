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
        if (!await userRepository.IsPasswordValidAsync(
            userContext.Username,
            request.OldPassword,
            cancellationToken))
        {
            return Result.Failure(UserErrors.InvalidPassword);
        }

        var user = await userRepository.GetByUsernameAsync(
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
