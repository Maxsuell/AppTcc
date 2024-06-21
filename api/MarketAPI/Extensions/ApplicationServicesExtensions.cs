using MarketAPI.Data;
using MarketAPI.Entities;
using MarketAPI.Helpers;
using MarketAPI.ServicesSystem;
using Microsoft.AspNetCore.Identity;

namespace MarketAPI.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {                
                services.AddScoped<StorageRepository>();
                services.AddScoped<ServicesRepository>();               
                services.AddScoped<TokenService>();
                
                services.AddScoped<UnitOfWork>();                
                
                services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
                            

                return services;
        }
    }
}