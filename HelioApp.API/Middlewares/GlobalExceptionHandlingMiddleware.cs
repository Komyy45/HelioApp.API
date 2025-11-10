using System.Text.Json;

namespace HelioApp.API.Middlewares;

internal sealed class GlobalExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var res = new
            {
                message = ex.Message
            };

            var json = JsonSerializer.Serialize(res);

            await context.Response.WriteAsync(json);
        }
    }
}