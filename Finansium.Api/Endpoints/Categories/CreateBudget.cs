using Finansium.Application.Categories.Commands.CreateBudget;

namespace Finansium.Api.Endpoints.Categories;

internal sealed class CreateBudget : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("categories/expense/budget", async (CreateCategoryBudgetCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Categories);
    }
}
