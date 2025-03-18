using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TailorPadi.Data.Entities;
using TailorPadi.Infrastructure.ModelConfiguration;

namespace TailorPadi.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser, AppRole, long>(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();
        builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
              options => options.EnableRetryOnFailure(
                  maxRetryCount: 5,
                  maxRetryDelay: TimeSpan.FromSeconds(30),
                  errorNumbersToAdd: null
              ));

        base.OnConfiguring(builder);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AppRoleConfiguration());
        base.OnModelCreating(builder);
    }
}
