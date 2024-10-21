using Finansium.Domain.Accounts;

namespace Finansium.Application.Accounts.Commands.Delete;

internal sealed class DeleteAccountCommandHandler(IAccountRepository accountRepository) 
    : ICommandHandler<DeleteAccountCommand>
{
    public async Task<Result> Handle(
        DeleteAccountCommand request, 
        CancellationToken cancellationToken)
    {
        await accountRepository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
