namespace Finansium.Domain.Accounts;

public interface IAccountTransferRepository
{
    void Add(AccountTransfer accountTransfer);
}
