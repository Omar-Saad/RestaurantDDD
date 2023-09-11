using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantDDD.Application.Common.Interfaces.Authentication;
using RestaurantDDD.Application.Common.Interfaces.Persistence;
using RestaurantDDD.Application.Common.Interfaces.Repositories;
using RestaurantDDD.Infrastructure.Authentication;
using RestaurantDDD.Infrastructure.Persistence;
using RestaurantDDD.Infrastructure.Persistence.Repositories;
using System.Text;

namespace RestaurantDDD.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.
                AddAuth(configuration)
                .AddPersistence(configuration);
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
        public static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<RestaurantDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddScoped<IMenuRepository, MenuRepository>();
            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services,
          ConfigurationManager configuration)
        {
            JwtSettings jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(
                defaultScheme: JwtBearerDefaults.AuthenticationScheme
                ).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                          Encoding.UTF8.GetBytes(jwtSettings.Secret))
                    };
                }
                );

            return services;
        }
    }
}
