namespace Finansium.Application.Abstractions.Authentication;

public interface IUserContext
{
    string Username { get; }
    Ulid UserId { get; }
}
