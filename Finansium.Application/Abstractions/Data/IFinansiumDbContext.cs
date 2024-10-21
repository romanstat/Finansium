using Finansium.Domain.Accounts;
using Finansium.Domain.Counties;

namespace Finansium.Application.Abstractions.Data;

public interface IFinansiumDbContext
{
    DbSet<Account> Accounts { get; }

    DbSet<Country> Countries { get; }

    DbSet<User> Users { get; }
}
