namespace MinimalApiPlayground;

public interface IModule
{
    IServiceCollection RegisterModule(IServiceCollection builder);

    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}
