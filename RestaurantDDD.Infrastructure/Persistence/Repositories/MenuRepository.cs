using RestaurantDDD.Application.Common.Interfaces.Repositories;
using RestaurantDDD.Domain.MenuAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly RestaurantDbContext _context;

        public MenuRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public void Add(Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();
        }
    }
}
