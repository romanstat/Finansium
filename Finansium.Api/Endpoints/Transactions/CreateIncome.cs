using Finansium.Application.Transactions.Commands.CreateIncome;

namespace Finansium.Api.Endpoints.Transactions;

internal sealed class CreateIncome : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("transactions/income", async (CreateIncomeTransactionCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Transactions);
    }
}
