namespace Finansium.Application.Users.Commands.UpdatePassword;

internal sealed class UpdateUserPasswordCommandValidator : AbstractValidator<UpdateUserPasswordCommand>
{
    private const int NEW_PASSWORD_MINIMUM_LENGTH = 8;
    private const string PASSWORD_REGEX = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$";

    public UpdateUserPasswordCommandValidator()
    {
        RuleFor(x => x.OldPassword)
            .NotEmpty()
            .WithMessage("Старый пароль не может быть пустым");

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .WithMessage("Новый пароль не может быть пустым")
            .MinimumLength(NEW_PASSWORD_MINIMUM_LENGTH)
            .WithMessage("Минимальная длина пароля 8 символов")
            .Matches(PASSWORD_REGEX)
            .WithMessage("Новый пароль должен содержать: цифры, от 1 символа в нижнем и в верхнем регистрах");

        RuleFor(x => new { x.OldPassword, x.NewPassword })
            .Must(x => x.NewPassword != x.OldPassword)
            .WithMessage("Пароли совпадают. Введите повторно пароль и подтверждение");

        RuleFor(x => new { x.NewPassword, x.RetryPassword })
            .Must(x => x.NewPassword == x.RetryPassword)
            .WithMessage("Новый пароль и подтверждение не совпадают");
    }
}
