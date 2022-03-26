using Conduit.Articles.Core;
using Conduit.Articles.Core.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Slugify;

namespace Conduit.Articles.Interface;

public static class ServiceCollectionExtensions
{
    public static void AddArticlesComponent(this IServiceCollection services, Action<DbContextOptionsBuilder> databaseOptions)
    {
        services.AddScoped<IArticlesComponent, ArticlesComponent>();
        services.AddScoped<ISlugHelper, SlugHelper>();
        services.AddScoped<IArticlesRepository, DbArticlesRepository>();
        services.AddDbContext<ArticleContext>(databaseOptions);
    }
}