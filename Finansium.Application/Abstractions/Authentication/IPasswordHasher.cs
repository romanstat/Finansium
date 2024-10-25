namespace Finansium.Application.Abstractions.Authentication;

public interface IPasswordHasher
{
    string Hash(string password);
    bool VerifyPassword(string password, string passwordHash);
}
