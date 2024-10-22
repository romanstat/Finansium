using Finansium.Application.Categories.Commands.CreateExpense;

namespace Finansium.Api.Endpoints.Categories;

internal sealed class CreateExpense : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("categories/expense", async (CreateExpenseCategoryCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Categories);
    }
}
