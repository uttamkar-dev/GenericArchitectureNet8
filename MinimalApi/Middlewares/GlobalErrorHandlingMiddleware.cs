using Microsoft.AspNetCore.Diagnostics;

namespace MinimalApi.Middlewares;

public static class GlobalErrorHandlingMiddleware
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    // Log here
                    await context.Response.WriteAsJsonAsync(new
                    {
                        StatusCodeContext = context.Response.StatusCode,
                        Message = "Internal Server Error"
                    });
                }
            });
        });
    }
}
