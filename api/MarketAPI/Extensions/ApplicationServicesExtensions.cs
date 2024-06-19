using MarketAPI.Data;
using MarketAPI.Helpers;

namespace MarketAPI.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
                services.AddScoped<UserRepository>();
                services.AddScoped<ClientRepository>();
                services.AddScoped<UnitOfWork>();                
                
                services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

                return services;
        }
    }
}