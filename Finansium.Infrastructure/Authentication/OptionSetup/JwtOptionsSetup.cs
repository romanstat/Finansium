namespace Finansium.Infrastructure.Authentication.OptionSetup;

internal sealed class JwtOptionsSetup(IConfiguration configuration) : IConfigureNamedOptions<JwtOptions>
{
    private const string ConfigureSectionName = "Jwt";

    public void Configure(string? name, JwtOptions options)
    {
        Configure(options);
    }

    public void Configure(JwtOptions options)
    {
        configuration.GetSection(ConfigureSectionName).Bind(options);
    }
}
