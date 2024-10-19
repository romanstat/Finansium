﻿using Finansium.Domain.Counties;

namespace Finansium.Application.Users.Commands.Register;

internal sealed class RegisterUserCommandHandler(
    ICountryRepository countryRepository,
    IUserRepository userRepository) : ICommandHandler<RegisterUserCommand>
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

        var user = User.Create(
            request.CountryId,
            request.Name,
            request.Surname,
            request.Username,
            emailResult.Value,
            request.Password);

        userRepository.Add(user);

        return Result.Success();
    }
}