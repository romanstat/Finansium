using Finansium.Application.Categories.Commands.CreateIncome;

namespace Finansium.Api.Endpoints.Categories;

internal sealed class CreateIncome : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("categories/income", async (CreateIncomeCategoryCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Categories);
    }
}
