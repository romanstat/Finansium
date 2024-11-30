using Finansium.Domain.Counties;

namespace Finansium.Application.Users.Commands.Register;

internal sealed class RegisterUserCommandHandler(
    TimeProvider timeProvider,
    ICountryRepository countryRepository,
    IUserRepository userRepository,
    IPasswordHasher passwordHasher) : ICommandHandler<RegisterUserCommand>
{
    public async Task<Result> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var emailResult = Email.Create(request.Email);

        if (emailResult.IsFailure)
        {
            return Result.Failure(emailResult.Error);
        }

        if (!await userRepository.IsUsernameUniqueAsync(request.Username, cancellationToken))
        {
            return Result.Failure(UserErrors.UsernameUnique(request.Username));
        }

        if (!await userRepository.IsEmailUniqueAsync(emailResult.Value, cancellationToken))
        {
            return Result.Failure(EmailErrors.IsUnique);
        }

        var country = await countryRepository.GetByIdNoTrackingAsync(
            request.CountryId, 
            cancellationToken);

        if (country is null)
        {
            return Result.Failure(CountryErrors.NotFound(request.CountryId));
        }

        var currency = Currency.FromCode(request.Currency);

        var user = User.Create(
            request.CountryId,
            currency,
            request.Name,
            request.Surname,
            request.Patronymic,
            request.Username,
            emailResult.Value,
            passwordHasher.Hash(request.Password),
            timeProvider.GetUtcNow());

        userRepository.Add(user);

        return Result.Success();
    }
}
