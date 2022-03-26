using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace Conduit.RestApi;

public static class ExceptionMappingWebApplicationExtensions
{
    public static void UseExceptionMappings(this WebApplication app, IReadOnlyDictionary<Type, HttpStatusCode> mappings)
    {
        app.UseExceptionHandler(appBuilder =>
        {
            appBuilder.Run(handler =>
            {
                var exception = handler.Features.Get<IExceptionHandlerPathFeature>()!.Error;

                if (mappings.TryGetValue(exception.GetType(), out var statusCode))
                {
                    handler.Response.StatusCode = (int)statusCode;
                    return Task.CompletedTask;
                }

                handler.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Task.CompletedTask;
            });
        });
    }
}