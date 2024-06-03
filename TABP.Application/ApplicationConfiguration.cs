using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using TABP.Application.Security;

namespace TABP.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddAuthorizationBuilder()
                    .AddPolicy("MatchUserId", policy =>
                policy.Requirements.Add(new MustMatchUserIdRequirement()));
        services.AddScoped<IAuthorizationHandler, MustMatchUserIdHandler>();
        
        return services;
    }
}