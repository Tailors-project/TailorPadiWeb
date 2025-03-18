using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TailorPadi.Infrastructure;

public static class InfrastructureServicesCollection
{
    public static void InitServices(IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
    }

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var applicationConnectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(op =>
        {
            op.UseSqlServer(applicationConnectionString,
                builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
        });
    }
}