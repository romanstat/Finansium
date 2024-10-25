using System.Security.Cryptography;
using Finansium.Application.Abstractions.Authentication;

namespace Finansium.Infrastructure.Authentication;

internal sealed class PasswordHasher : IPasswordHasher
{
    private const int SALT_SIZE = 16;
    private const int HASH_SIZE = 32;
    private const int ITERATIONS = 100000;

    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

    public string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SALT_SIZE);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, ITERATIONS, Algorithm, HASH_SIZE);

        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        var parts = passwordHash.Split('-');
        var hash = Convert.FromHexString(parts[0]);
        var salt = Convert.FromHexString(parts[1]);

        var inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, ITERATIONS, Algorithm, HASH_SIZE);

        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }
}
