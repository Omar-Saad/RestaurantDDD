using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RestaurantDDD.Application.Authentication.Commands;
using RestaurantDDD.Application.Authentication.Common;
using RestaurantDDD.Application.Common.Behaviors;
using System.Reflection;

namespace RestaurantDDD.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));

            services.AddScoped(typeof(IPipelineBehavior<,>) , typeof(ValidationCommandBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}



