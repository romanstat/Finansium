namespace Finansium.Application;

public static class DependencyInjection
{
    public static readonly Assembly ApplicationAssembly = Assembly.GetExecutingAssembly();

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(ApplicationAssembly);

            config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(TransactionalPipelineBehavior<,>));
        });

        services.AddValidatorsFromAssembly(ApplicationAssembly, includeInternalTypes: true);

        return services;
    }
}
