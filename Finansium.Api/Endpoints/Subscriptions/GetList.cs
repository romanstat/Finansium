using Finansium.Application.Subscriptions.Queries.GetList;

namespace Finansium.Api.Endpoints.Subscriptions;

internal sealed class GetList : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("subscriptions/type/list", async (ISender sender) =>
        {
            var result = await sender.Send(new GetSubscriptionTypeListQuery());

            return result.Match(Results.Ok, ApiResults.Problem);
        })
            .AllowAnonymous()
            .WithTags(Tags.Subscriptions);
    }
}
