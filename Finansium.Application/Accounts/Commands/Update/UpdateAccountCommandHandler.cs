namespace Finansium.Application.Accounts.Commands.Update;

internal sealed class UpdateAccountCommandHandler(
    TimeProvider timeProvider,
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

        account.Update(request.Name, timeProvider.GetUtcNow());

        return Result.Success();
    }
}
