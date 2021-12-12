using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace Toolkit.FeatureModules;

public sealed class DependencyContextAssemblyRegister
{
    private readonly DependencyContext dependencyContext;

    public DependencyContextAssemblyRegister()
    {
        dependencyContext = DependencyContext.Load(Assembly.GetEntryAssembly());
    }

    public IReadOnlyCollection<Assembly> GetAssemblies()
    {
        var results = new List<Assembly>();

        foreach (var library in dependencyContext.RuntimeLibraries)
        {
            if (library.Dependencies.Any(dependency => dependency.Name.Equals(typeof(FeatureModuleExtensions).Assembly.GetName().Name)))
            {
                foreach (var assembly in library.GetDefaultAssemblyNames(dependencyContext))
                {
                    results.Add(Assembly.Load(assembly));
                }
            }
        }

        return results;
    }
}
