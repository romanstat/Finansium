using Finansium.Domain.Accounts;

namespace Finansium.Persistence.Repositories;

internal sealed class AccountTransferRepository(FinansiumDbContext dbContext)
    : Repository<AccountTransfer>(dbContext), IAccountTransferRepository
{
}
