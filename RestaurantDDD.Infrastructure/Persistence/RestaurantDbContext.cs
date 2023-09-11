using Microsoft.EntityFrameworkCore;
using RestaurantDDD.Domain.MenuAggregate;

namespace RestaurantDDD.Infrastructure.Persistence
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> optionss):base(optionss)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestaurantDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Menu> Menus { get; set; }
    }
}
