using System.Transactions;

namespace Finansium.Application.Abstractions.Behaviors;

internal sealed class TransactionalPipelineBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var response = await next();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        scope.Complete();

        return response;
    }
}
