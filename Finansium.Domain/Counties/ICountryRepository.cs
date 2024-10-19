
namespace Finansium.Domain.Counties;

public interface ICountryRepository
{
    Task<Country?> GetByIdNoTrackingAsync(Ulid Id, CancellationToken cancellationToken);
}
