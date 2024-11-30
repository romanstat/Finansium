using Finansium.Application.Analystics.Queries.Get;

namespace Finansium.Api.Endpoints.Analystics;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("analystics", async (GetAnalysticsQuery query, ISender sender) =>
        {
            var result = await sender.Send(query);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Analystics);
    }
}
