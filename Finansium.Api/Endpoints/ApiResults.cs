namespace Finansium.Api.Endpoints;

public static class ApiResults
{
    public static IResult Problem(Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException("Результат не может быть успешным");
        }

        return Results.Problem(
            title: result.Error.Code,
            detail: result.Error.Description,
            type: GetType(result.Error.Type),
            statusCode: GetStatusCode(result.Error.Type),
            extensions: GetErrors(result));

        static string GetType(ErrorTypes errorType) =>
            errorType switch
            {
                ErrorTypes.Failure => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                ErrorTypes.Validation => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                ErrorTypes.Problem => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                ErrorTypes.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                ErrorTypes.Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                ErrorTypes.AccessDenied => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3",
                _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

        static int GetStatusCode(ErrorTypes errorType) =>
            errorType switch
            {
                ErrorTypes.Failure => StatusCodes.Status400BadRequest,
                ErrorTypes.Validation => StatusCodes.Status400BadRequest,
                ErrorTypes.Problem => StatusCodes.Status400BadRequest,
                ErrorTypes.NotFound => StatusCodes.Status404NotFound,
                ErrorTypes.Conflict => StatusCodes.Status409Conflict,
                ErrorTypes.AccessDenied => StatusCodes.Status403Forbidden,
                _ => StatusCodes.Status500InternalServerError
            };

        static Dictionary<string, object?>? GetErrors(Result result)
        {
            if (result.Error is not ValidationError validationError)
            {
                return null;
            }

            return new Dictionary<string, object?>
            {
                { "errors", validationError.Errors }
            };
        }
    }
}
