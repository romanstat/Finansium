namespace Finansium.Domain.Abstractions;

public enum ErrorTypes
{
    None = 0,
    Failure = 1,
    Validation = 2,
    Problem = 3,
    NotFound = 4,
    Conflict = 5,
    AccessDenied = 6
}