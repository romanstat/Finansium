namespace Finansium.Domain.Users;

public sealed record Email
{
    public string Value { get; private set; }

    public static Result<Email> Create(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return Result.Failure<Email>(EmailErrors.Empty);
        }

        if (value.Split('@').Length != 2)
        {
            return Result.Failure<Email>(EmailErrors.InvalidFormat);
        }

        var email = new Email
        {
            Value = value
        };

        return email;
    }
}
