using Finansium.Application.Categories.Commands.Delete;

namespace Finansium.Api.Endpoints.Categories;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("categories/{id}", async (Ulid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteCategoryCommand(id));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Categories);
    }
}
