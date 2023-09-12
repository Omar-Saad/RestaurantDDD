using Microsoft.EntityFrameworkCore;
using RestaurantDDD.Domain.CommonAggregate.Models;
using RestaurantDDD.Domain.MenuAggregate;
using RestaurantDDD.Infrastructure.Persistence.Interceptors;

namespace RestaurantDDD.Infrastructure.Persistence
{
    public class RestaurantDbContext : DbContext
    {
        private readonly PublishDomainEventsInterceptor _publishDomainEvents;

        public RestaurantDbContext(PublishDomainEventsInterceptor publishDomainEvents)
        {
            _publishDomainEvents = publishDomainEvents;
        }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> optionss):base(optionss)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.
                Ignore<List<IDomianEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(RestaurantDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEvents);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Menu> Menus { get; set; }
    }
}
