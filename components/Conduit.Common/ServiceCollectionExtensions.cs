using Microsoft.Extensions.DependencyInjection;

namespace Conduit.Common;

public static class ServiceCollectionExtensions
{
    public static void AddCommon(this IServiceCollection services)
    {
        services.AddScoped<ITimekeeper, Timekeeper>();
    } 
}