using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.MenuAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.MenuAggregate.Entities
{
    public class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();

        public string Name { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
        protected MenuSection() { }
        private MenuSection(MenuSectionId id, string name, string description, List<MenuItem> items) : base(id)
        {
            Name = name;
            Description = description;
            _items = items;
        }

        public static MenuSection Create(
          string name,
          string description,
          List<MenuItem> items
          ) => new(MenuSectionId.CreateUnique(), name, description, items);
    }
}
