using System.Text;
using MarketAPI.Data;
using MarketAPI.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace api.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {            

            services.AddIdentityCore<AppUser>(opt => 
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;                                    
                
            })
            .AddRoles<AppRole>()            
            .AddRoleManager<RoleManager<AppRole>>()
            .AddSignInManager<SignInManager<AppUser>>()
            .AddRoleValidator<RoleValidator<AppRole>>()
            .AddEntityFrameworkStores<DataContext>();            

            

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option => 
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                option.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context => 
                    {
                        var accessToken = context.Request.Query["access_token"];

                        var path = context.HttpContext.Request.Path;

                        if(!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
                        {
                            context.Token = accessToken;
                        
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            

            services.AddAuthorization(opt => 
            {
                opt.AddPolicy("User", policy => policy.RequireRole("User"));
                opt.AddPolicy("Clients", policy => policy.RequireRole("Client"));                
            });            


            return services;
        }
    }
}