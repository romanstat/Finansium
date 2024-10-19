namespace Finansium.Infrastructure.Authentication.OptionSetup;

internal sealed record JwtOptions
{
    public string Issuer { get; set; }

    public string Audience { get; set; }

    public string Key { get; set; }

    public int AccessTokenTimeInMinutes { get; set; }

    public int RefreshTokenTimeInMinutes { get; set; }

    internal byte[] KeyAsBytes => Encoding.UTF8.GetBytes(Key);
}
