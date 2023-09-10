using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.Menu.Entities
{
    public class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();

        public string Name { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(MenuSectionId id, string name, string description):base(id) 
        {
            Name = name;
            Description = description;
        }

        public static MenuSection Create(
          string name,
          string description
          ) => new(MenuSectionId.CreateUnique(), name, description);
    }
}
