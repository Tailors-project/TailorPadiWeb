using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TailorPadi.Core.Service;

public static class CoreBootstrapper
{
    public static void InitServices(IServiceCollection services)
    {
        AutoInjectLayers(services);
    }

    private static void AutoInjectLayers(IServiceCollection serviceCollection)
    {
        var assembly = Assembly.GetCallingAssembly();
        serviceCollection.Scan(scan => scan.FromAssemblies(assembly).AddClasses(classes => classes
                .Where(type => type.Name.EndsWith("Repository") || type.Name.EndsWith("Service")), false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}
