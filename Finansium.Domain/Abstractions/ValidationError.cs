namespace Finansium.Domain.Abstractions;

public sealed record ValidationError(Error[] Errors)
    : Error(
        nameof(ValidationError),
        "Произошла одна или несколько ошибок валидации",
        ErrorTypes.Validation)

{
    public static ValidationError FromResults(IEnumerable<Result> results) =>
        new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
}
