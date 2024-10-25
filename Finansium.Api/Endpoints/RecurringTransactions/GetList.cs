using Finansium.Application.RecurringTransactions.Queries.GetList;

namespace Finansium.Api.Endpoints.RecurringTransactions;

internal sealed class GetList : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("recurring-transactions/list", async (GetRecurringTransactionsQuery query, ISender sender) =>
        {
            var result = await sender.Send(query);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.RecurringTransactions);
    }
}
