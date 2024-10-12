namespace Finansium.Domain.Abstractions;

public record Error(
    string Code,
    string Description,
    ErrorTypes Type)
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorTypes.Failure);
    public static readonly Error NullValue = new(
        $"{nameof(Error)}.{nameof(NullValue)}",
        "Было указано пустое значение",
        ErrorTypes.Failure);

    public static Error Failure(string code, string description) =>
        new(code, description, ErrorTypes.Failure);

    public static Error NotFound(string code, string description) =>
        new(code, description, ErrorTypes.NotFound);

    public static Error Problem(string code, string description) =>
        new(code, description, ErrorTypes.Problem);

    public static Error Conflict(string code, string description) =>
        new(code, description, ErrorTypes.Conflict);

    public static Error Validation(string code, string description) =>
        new(code, description, ErrorTypes.Validation);
}
