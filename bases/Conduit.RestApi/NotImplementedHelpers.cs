using Microsoft.AspNetCore.Diagnostics;

namespace Conduit.RestApi;

public static class NotImplementedHelpers
{
    public static readonly RequestDelegate NotImplemented = _ => throw new NotImplementedException();

    public static Task NotImplementedHandler(HttpContext handler)
    {
        var exception = handler.Features.Get<IExceptionHandlerPathFeature>()!.Error;

        if (exception is NotImplementedException)
        {
            handler.Response.StatusCode = StatusCodes.Status501NotImplemented;
        }

        return Task.CompletedTask;
    }
}