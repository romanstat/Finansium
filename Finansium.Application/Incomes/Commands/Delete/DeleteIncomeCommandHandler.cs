using Finansium.Domain.Incomes;

namespace Finansium.Application.Incomes.Commands.Delete;

internal sealed class DeleteIncomeCommandHandler(IIncomeRepository incomeRepository)
    : ICommandHandler<DeleteIncomeCommand>
{
    public async Task<Result> Handle(
        DeleteIncomeCommand request, 
        CancellationToken cancellationToken)
    {
        await incomeRepository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
