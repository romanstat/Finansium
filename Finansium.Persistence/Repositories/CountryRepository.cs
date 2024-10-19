using Finansium.Domain.Counties;

namespace Finansium.Persistence.Repositories;

internal sealed class CountryRepository(FinansiumDbContext dbContext)
    : Repository<Country>(dbContext), ICountryRepository
{
}
