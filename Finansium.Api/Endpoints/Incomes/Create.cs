using Finansium.Application.Incomes.Commands.Create;

namespace Finansium.Api.Endpoints.Incomes;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("incomes", async (CreateIncomeCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Incomes);
    }
}
