namespace Finansium.Persistence.Options;

public class DatabaseOptionsSetup(IConfiguration configuration) : IConfigureOptions<DatabaseOptions>
{
    private const string DatabaseSectionName = "Finansium";

    public void Configure(DatabaseOptions options)
    {
        var connectionString = configuration.GetConnectionString(DatabaseSectionName)!;

        options.ConnectionString = connectionString;
    }
}
