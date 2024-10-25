using Finansium.Application.Transactions.Queries.Search;

namespace Finansium.Api.Endpoints.Transactions;

internal sealed class Search : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("transactions/search", async (SearchTransactionQuery query, ISender sender) =>
        {
            var result = await sender.Send(query);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Transactions);
    }
}
