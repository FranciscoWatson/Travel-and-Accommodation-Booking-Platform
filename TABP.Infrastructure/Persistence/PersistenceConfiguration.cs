using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TABP.Application.Interfaces.Repositories;
using TABP.Infrastructure.Persistence.Repositories;

namespace TABP.Infrastructure.Persistence;

public static class PersistenceConfiguration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TabpDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

        services.AddRepositories();
        
        return services;
    }
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAmenityRepository , AmenityRepository>();
        services.AddScoped<IBookingRepository , BookingRepository>();
        services.AddScoped<ICityRepository , CityRepository>();
        services.AddScoped<ICountryRepository , CountryRepository>();
        services.AddScoped<IHotelImageRepository, HotelImageRepository>();
        services.AddScoped<IHotelRepository , HotelRepository>();
        services.AddScoped<IOwnerRepository , OwnerRepository>();
        services.AddScoped<IPaymentRepository , PaymentRepository>();
        services.AddScoped<IReviewRepository , ReviewRepository>();
        services.AddScoped<IDiscountRepository , DiscountRepository>();
        services.AddScoped<IRoomImageRepository , RoomImageRepository>();
        services.AddScoped<IRoomRepository , RoomRepository>();
        services.AddScoped<IRoomTypeRepository , RoomTypeRepository>();
        services.AddScoped<IUserRepository , UserRepository>();
        services.AddScoped<IUserRoleRepository , UserRoleRepository>();
        
        return services;
    }
}
