using Finansium.Domain.RecurringTransactions;

namespace Finansium.Application.RecurringTransactions.Commands.Delete;

internal sealed class DeleteRecurringTransactionCommandHandler(
    IRecurringTransactionRepository recurringTransactionRepository)
    : ICommandHandler<DeleteRecurringTransactionCommand>
{
    public async Task<Result> Handle(
        DeleteRecurringTransactionCommand request, 
        CancellationToken cancellationToken)
    {
        await recurringTransactionRepository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
