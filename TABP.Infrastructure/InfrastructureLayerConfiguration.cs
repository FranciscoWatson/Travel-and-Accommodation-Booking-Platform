using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TABP.Infrastructure.Authentication;
using TABP.Infrastructure.Persistence;

namespace TABP.Infrastructure;

public static class InfrastructureLayerConfiguration
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthenticationServices(configuration);
        services.AddPersistenceServices(configuration);
        return services;
    }
}