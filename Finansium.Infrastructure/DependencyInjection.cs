namespace Finansium.Infrastructure;

public static class DependencyInjection
{
    public static readonly Assembly InfrastructureAssembly = Assembly.GetExecutingAssembly();

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
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
