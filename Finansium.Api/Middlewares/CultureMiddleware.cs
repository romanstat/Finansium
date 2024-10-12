using System.Globalization;

namespace Finansium.Api.Middlewares;

public class CultureMiddleware : IMiddleware
{
    public const string DefaultCulture = "ru-RU";

    public async Task InvokeAsync(
        HttpContext context,
        RequestDelegate next)
    {
        SetDecimalSeparatorCultureToThread();

        await next(context);
    }

    private static void SetDecimalSeparatorCultureToThread()
    {
        var cultureInfo = new CultureInfo(DefaultCulture);

        cultureInfo.NumberFormat.NumberDecimalSeparator = ".";

        Thread.CurrentThread.CurrentCulture = cultureInfo;
    }
}
