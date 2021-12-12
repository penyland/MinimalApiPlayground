using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace Toolkit.FeatureModules;

public static class FeatureModuleExtensions
{
    // this could also be added into the DI container
    private static readonly List<IFeatureModule> RegisteredModules = new();

    public static IServiceCollection AddFeatureModules(this IServiceCollection services)
    {
        SetupFeatureModules(services);

        return services;
    }

    public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder)
    {
        var modules = DiscoverModules();
        foreach (var module in modules)
        {
            module.RegisterModule(builder.Services);
            RegisteredModules.Add(module);
        }

        return builder;
    }

    public static void MapFeatureModuleEndpoints(this IEndpointRouteBuilder builder)
    {
        foreach (var module in RegisteredModules)
        {
            module.MapEndpoints(app);
        }
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        foreach (var module in RegisteredModules)
        {
            module.MapEndpoints(app);
        }

        return app;
    }

    private static void SetupFeatureModules(IServiceCollection services)
    {
        var modules = DiscoverModules();

        DependencyContext dependencyContext;
    }

    private static IEnumerable<IFeatureModule> DiscoverModules()
    {
        return typeof(IFeatureModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IFeatureModule)))
            .Select(Activator.CreateInstance)
            .Cast<IFeatureModule>();
    }
}
