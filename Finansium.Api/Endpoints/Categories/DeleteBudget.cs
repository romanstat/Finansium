using Finansium.Application.Categories.Commands.DeleteBudget;

namespace Finansium.Api.Endpoints.Categories;

internal sealed class DeleteBudget : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("categories/expense/budget/{id}", async (Ulid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteCategoryBudgetCommand(id));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Categories);
    }
}

