using Finansium.Application.Incomes.Commands.Delete;

namespace Finansium.Api.Endpoints.Incomes;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("incomes/{id}", async (Ulid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteIncomeCommand(id));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Incomes);
    }
}
