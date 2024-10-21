namespace Finansium.Application.Users.Commands.Register;

internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    private const int PASSWORD_MINIMUM_LENGTH = 8;
    private const string PASSWORD_REGEX = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$";

    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Пароль не может быть пустым")
            .MinimumLength(PASSWORD_MINIMUM_LENGTH)
            .WithMessage("Минимальная длина пароля 8 символов")
            .Matches(PASSWORD_REGEX)
            .WithMessage("Пароль должен содержать: цифры, от 1 символа в нижнем и в верхнем регистрах");

        RuleFor(x => new { x.Password, x.RetryPassword })
            .Must(x => x.Password == x.RetryPassword)
            .WithMessage("Пароль и подтверждение не совпадают");
    }
}
