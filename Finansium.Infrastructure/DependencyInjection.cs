using Finansium.Application.Abstractions.Authentication;
using Finansium.Infrastructure.Authentication.OptionSetup;
using Finansium.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Finansium.Infrastructure;

public static class DependencyInjection
{
    public static readonly Assembly InfrastructureAssembly = Assembly.GetExecutingAssembly();

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddAuthorization();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer();

        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();

        services.AddScoped<IUserContext, UserContext>();
        services.AddScoped<ITokenProvider, TokenProvider>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();

        services.AddHttpContextAccessor();

        services.AddAppHealthChecks();

        return services;
    }

    private static IServiceCollection AddAppHealthChecks(this IServiceCollection services)
    {
        var databaseOptions = services.BuildServiceProvider()
            .GetRequiredService<IOptions<DatabaseOptions>>()
            .Value;

        services.AddHealthChecks().AddNpgSql(databaseOptions.ConnectionString);

        return services;
    }
}
