namespace Finansium.Application.Users.Commands.Update;

internal sealed class UpdateUserCommandHandler(
    IUserRepository userRepository)
    : ICommandHandler<UpdateUserCommand>
{
    public async Task<Result> Handle(
        UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
        {
            return Result.Failure(UserErrors.NotFound(request.Id));
        }

        user.Update(
            request.Name,
            request.Surname,
            request.Patronymic);

        return Result.Success();
    }
}
