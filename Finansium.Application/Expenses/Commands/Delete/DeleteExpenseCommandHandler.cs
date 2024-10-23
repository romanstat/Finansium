using Finansium.Application.Incomes.Commands.Delete;
using Finansium.Domain.Expenses;

namespace Finansium.Application.Expenses.Commands.Delete;

internal sealed class DeleteExpenseCommandHandler(IExpenseRepository expenseRepository)
    : ICommandHandler<DeleteIncomeCommand>
{
    public async Task<Result> Handle(
        DeleteIncomeCommand request,
        CancellationToken cancellationToken)
    {
        await expenseRepository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
