using Finansium.Domain.Accounts;

namespace Finansium.Application.Accounts.Commands.Create;

internal sealed class CreateAccountCommandHandler(
    IUserContext userContext,
    TimeProvider timeProvider,
    IAccountRepository accountRepository)
    : ICommandHandler<CreateAccountCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        CreateAccountCommand request,
        CancellationToken cancellationToken)
    {
        if (await accountRepository.IsExistsAsync(
            userContext.UserId,
            request.Name,
            cancellationToken))
        {
            return Result.Failure<Ulid>(AccountErrors.IsExists(request.Name));
        }

        var balance = new Money(
            request.Amount,
            Currency.FromCode(request.Currency));

        var account = Account.Create(
            userContext.UserId,
            request.Name,
            balance,
            timeProvider);

        accountRepository.Add(account);

        return account.Id;
    }
}
