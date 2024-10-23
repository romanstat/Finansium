using Finansium.Application.Incomes.Commands.Update;

namespace Finansium.Api.Endpoints.Incomes;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("incomes", async (UpdateIncomeCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Incomes);
    }
}
