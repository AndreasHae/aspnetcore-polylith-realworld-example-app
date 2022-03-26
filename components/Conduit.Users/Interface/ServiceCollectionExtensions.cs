using Conduit.Users.Core;
using Conduit.Users.Core.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Conduit.Users.Interface;

public static class ServiceCollectionArticleExtensions
{
    public static void AddUsersComponent(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder> databaseOptions)
    {
        services.AddScoped<IUsersComponent, UsersComponent>();
        services.AddScoped<IUserRepository, DbUserRepository>();
        services.AddDbContext<UserContext>(databaseOptions);
    }
}