using System.Net;
using System.Text.Json;

namespace BuberDinner.Api.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandlingExceptionAsync(context, exception);
        }
    }

    private static Task HandlingExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "applicaiton/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var result = JsonSerializer
                        .Serialize(new
                        {
                            error = "An Error Occured While Porcessing Your Request",
                            message = exception.Message
                        });
        return context.Response.WriteAsync(result);
    }
}