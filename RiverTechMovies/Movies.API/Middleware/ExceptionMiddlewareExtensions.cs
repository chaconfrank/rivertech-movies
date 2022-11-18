using System.Net;
using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Movies.Domain.Config;

namespace Movies.API.Middleware;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    logger.LogError("Something went wrong: | {Servicio} | {Error}", "PaymentsAPI", contextFeature.Error);

                    string message = contextFeature.Error.Message;

                    BaseResponse response = BaseResponse.InternalServerError();

                    if (contextFeature.Error is ApiException exception)
                    {
                        context.Response.StatusCode = (int)exception.StatusCode;
                        message = exception.Message;

                        response = new BaseResponse(exception.Message, false);
                    }

                    // Use System.Text.Json here just because the model is configured to ignore null values when using that serializer.
                    // TODO: Consider if we should switch to System.Text.Json everywhere
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                }
            });
        });
    }
}