using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Toolkit.FeatureModules;

public interface IFeatureModule
{
    IServiceCollection RegisterModule(IServiceCollection builder);

    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}
