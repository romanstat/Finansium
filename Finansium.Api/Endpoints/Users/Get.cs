using Finansium.Application.Users.Queries.Get;

namespace Finansium.Api.Endpoints.Users;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users", async (ISender sender) =>
        {
            var result = await sender.Send(new GetUserQuery());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .RequireAuthorization()
            .WithTags(Tags.Users);
    }
}
