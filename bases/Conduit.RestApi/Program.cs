using System.Net;
using Conduit.Articles.Interface;
using Conduit.Common;
using Conduit.RestApi;
using Conduit.Users.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCommon();
builder.Services.AddArticlesComponent(options => options.UseInMemoryDatabase("articles"));
builder.Services.AddUsersComponent(options => options.UseInMemoryDatabase("users"));

var app = builder.Build();

app.UsePathBase("/api");
app.UseExceptionMappings(new Dictionary<Type, HttpStatusCode>
{
    { typeof(NotImplementedException), HttpStatusCode.NotImplemented },
    { typeof(WrongPasswordException), HttpStatusCode.Unauthorized },
    { typeof(NotFoundException), HttpStatusCode.NotFound }
});
app.UseRouting();

app.MapPost("/users/login", ([FromBody] LoginUserRequest request, IUsersComponent users)
    => new UserResponse(users.Login(request.User)));
app.MapPost("/users", ([FromBody] RegisterUserRequest request, IUsersComponent users)
    => new UserResponse(users.Register(request.User)));
app.MapGet("/user", NotImplemented);
app.MapPut("/user", NotImplemented);

app.MapGet("/profiles/{username}", NotImplemented);
app.MapPost("/profiles/{username}/follow", NotImplemented);
app.MapDelete("/profiles/{username}/follow", NotImplemented);

app.MapGet("/articles/feed", NotImplemented);
app.MapGet("/articles", NotImplemented);
app.MapPost("/articles", ([FromBody] CreateArticleRequest request, IArticlesComponent articles)
    => new ArticleResponse(articles.Create(request.Article)));
app.MapGet("/articles/{slug}", (string slug, IArticlesComponent articles)
    => new ArticleResponse(articles.Get(slug)));
app.MapPut("/articles/{slug}", NotImplemented);
app.MapDelete("/articles/{slug}", NotImplemented);

app.MapGet("/articles/{slug}/comments", NotImplemented);
app.MapPost("/articles/{slug}/comments", NotImplemented);
app.MapDelete("/articles/{slug}/comments/{id}", NotImplemented);

app.MapPost("/articles/{slug}/favorite", NotImplemented);
app.MapDelete("/articles/{slug}/favorite", NotImplemented);

app.Run();

void NotImplemented() => throw new NotImplementedException();