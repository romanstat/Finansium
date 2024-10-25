using Finansium.Domain.Transactions;

namespace Finansium.Application.Transactions.Commands.Delete;

internal sealed class DeleteTransactionCommandHandler(ITransactionRepository transactionRepository)
    : ICommandHandler<DeleteTransactionCommand>
{
    public async Task<Result> Handle(
        DeleteTransactionCommand request,
        CancellationToken cancellationToken)
    {
        await transactionRepository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
