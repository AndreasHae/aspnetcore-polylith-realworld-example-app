using System.Net;
using Microsoft.AspNetCore.Diagnostics;

void NotImplemented()
{
    throw new NotImplementedException();
}

Task NotImplementedHandler(HttpContext handler)
{
    var exception = handler.Features.Get<IExceptionHandlerPathFeature>()!.Error;

    if (exception is NotImplementedException)
    {
        handler.Response.StatusCode = (int)HttpStatusCode.NotImplemented;
    }

    return Task.CompletedTask;
}

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UsePathBase("/api");
app.UseExceptionHandler((appBuilder) =>
{
    appBuilder.Run(NotImplementedHandler);
});
app.UseRouting();

app.MapPost("/users/login", NotImplemented);
app.MapPost("/users", NotImplemented);
app.MapGet("/user", NotImplemented);
app.MapPut("/user", NotImplemented);

app.MapGet("/profiles/{username}", NotImplemented);
app.MapPost("/profiles/{username}/follow", NotImplemented);
app.MapDelete("/profiles/{username}/follow", NotImplemented);

app.MapGet("/articles/feed", NotImplemented);
app.MapGet("/articles", NotImplemented);
app.MapPost("/articles", NotImplemented);
app.MapGet("/articles/{slug}", NotImplemented);
app.MapPut("/articles/{slug}", NotImplemented);
app.MapDelete("/articles/{slug}", NotImplemented);

app.MapGet("/articles/{slug}/comments", NotImplemented);
app.MapPost("/articles/{slug}/comments", NotImplemented);
app.MapDelete("/articles/{slug}/comments/{id}", NotImplemented);

app.MapPost("/articles/{slug}/favorite", NotImplemented);
app.MapDelete("/articles/{slug}/favorite", NotImplemented);

app.Run();