using System.Transactions;

namespace Finansium.Persistence.Seed;

public static class SeedData
{
    public static async Task SeedDataAsync(this IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetRequiredService<FinansiumDbContext>();

        if (await dbContext.Countries.AnyAsync())
        {
            return;
        }

        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        dbContext.Countries.AddRange(CountrySeed.Get());

        await dbContext.SaveChangesAsync();

        scope.Complete();
    }
}
