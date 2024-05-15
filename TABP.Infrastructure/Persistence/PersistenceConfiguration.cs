using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TABP.Infrastructure.Persistance;

public static class PersistenceConfiguration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TabpDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

        return services;
    }
}
