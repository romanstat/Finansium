using Finansium.Application.RecurringTransactions.Queries.Search;

namespace Finansium.Api.Endpoints.RecurringTransactions;

internal sealed class GetList : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("recurring-transactions/search", async (SearchRecurringTransactionsQuery query, ISender sender) =>
        {
            var result = await sender.Send(query);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.RecurringTransactions);
    }
}
