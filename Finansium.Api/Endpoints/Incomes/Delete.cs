using Finansium.Application.Incomes.Commands.Delete;

namespace Finansium.Api.Endpoints.Incomes;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("incomes", async (DeleteIncomeCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Incomes);
    }
}
