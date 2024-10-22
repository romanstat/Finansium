using Finansium.Application.News.Commands.Outdate;

namespace Finansium.Api.Endpoints.News;

internal sealed class Outdate : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("news/{id}/outdate", async (Ulid id, ISender sender) =>
        {
            var result = await sender.Send(new OutdateNewsCommand(id));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.News);
    }
}
