namespace Finansium.Persistence;

public static class DependencyInjection
{
    public static readonly Assembly PersistenceAssembly = Assembly.GetExecutingAssembly();

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();

        services.AddDbContext<FinansiumDbContext>(Schemas.FinansiumDbContext);

        services.AddScoped<IFinansiumDbContext, FinansiumDbContext>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<FinansiumDbContext>());

        services.AddRepositories();
        services.AddServices();

        return services;
    }

    private static IServiceCollection AddDbContext<T>(
        this IServiceCollection services,
        string migrationSchema)
        where T : DbContext
    {
        services.AddDbContext<T>((serviceProvider, dbContextOptionsBuilder) =>
        {
            var databaseOptions = serviceProvider
                .GetRequiredService<IOptionsMonitor<DatabaseOptions>>()
                .CurrentValue;

            dbContextOptionsBuilder
                .UseNpgsql(
                    databaseOptions.ConnectionString,
                    npgSqlOptions =>
                    {
                        npgSqlOptions.MigrationsHistoryTable(
                            HistoryRepository.DefaultTableName,
                            migrationSchema);
                    })
                .UseSnakeCaseNamingConvention();
        });

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(PersistenceAssembly)
            .AddClasses(
                filter => filter.Where(x => x.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase)),
                publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Throw)
            .AsMatchingInterface()
            .WithScopedLifetime());

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(PersistenceAssembly)
            .AddClasses(
                filter => filter.Where(x => x.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase)),
                publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Throw)
            .AsMatchingInterface()
            .WithScopedLifetime());

        return services;
    }
}
