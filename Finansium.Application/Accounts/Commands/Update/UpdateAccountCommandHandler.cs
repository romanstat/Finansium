using Finansium.Domain.Accounts;

namespace Finansium.Application.Accounts.Commands.Update;

internal sealed class UpdateAccountCommandHandler(
    IAccountRepository accountRepository) : ICommandHandler<UpdateAccountCommand>
{
    public async Task<Result> Handle(
        UpdateAccountCommand request,
        CancellationToken cancellationToken)
    {
        var account = await accountRepository.GetByIdAsync(request.Id, cancellationToken);

        if (account is null)
        {
            return Result.Failure(AccountErrors.NotFound(request.Id));
        }

        var balance = new Money(
            request.Amount,
            Currency.FromCode(request.Currency));

        account.Update(
            request.Name,
            balance,
            AccountStatus.FromName(request.Status));

        return Result.Success();
    }
}
