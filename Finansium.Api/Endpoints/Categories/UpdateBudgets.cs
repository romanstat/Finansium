using Finansium.Application.Categories.Commands.UpdateBudget;

namespace Finansium.Api.Endpoints.Categories;

internal sealed class UpdateBudgets : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/expense/budgets", async (UpdateCategoryBudgetCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Categories);
    }
}
