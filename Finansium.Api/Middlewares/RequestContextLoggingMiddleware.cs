using System.Security.Claims;
using Microsoft.Extensions.Primitives;

namespace Finansium.Api.Middlewares;

public class RequestContextLoggingMiddleware : IMiddleware
{
    private const string CorrelationIdHeaderName = "X-Correlation-Id";
    private const string UserAgentHeaderName = "User-Agent";

    public async Task InvokeAsync(
        HttpContext context,
        RequestDelegate next)
    {
        using (LogContext.PushProperty("CorrelationId", GetCorrelationId(context)))
        using (LogContext.PushProperty("Username", GetUsername(context)))
        using (LogContext.PushProperty("SourceIpAddress", GetSourceIpAddress(context)))
        using (LogContext.PushProperty("HostIpAddress", GetHostIpAddress(context)))
        using (LogContext.PushProperty("DeviceName", GetDeviceName(context)))
        {
            await next(context);
        }
    }

    private static string GetCorrelationId(HttpContext context)
    {
        context.Request.Headers.TryGetValue(
            CorrelationIdHeaderName,
            out StringValues correlationId);

        return correlationId.FirstOrDefault() ?? context.TraceIdentifier;
    }

    private static string? GetUsername(HttpContext context) =>
        context.User.FindFirstValue(ClaimTypes.NameIdentifier);

    private static string GetSourceIpAddress(HttpContext context) =>
        context.Connection.RemoteIpAddress!.ToString();

    private static string GetHostIpAddress(HttpContext context) =>
        context.Connection.LocalIpAddress!.ToString();

    private static string? GetDeviceName(HttpContext context) =>
        context.Request.Headers[UserAgentHeaderName]!.ToString();
}
