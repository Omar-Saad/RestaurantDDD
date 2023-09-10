using RestaurantDDD.API.Common.Mapping;

namespace RestaurantDDD.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMapping();
            return services;
        }
    }

}
