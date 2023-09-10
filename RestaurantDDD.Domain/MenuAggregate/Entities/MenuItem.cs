﻿using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private MenuItem(MenuItemId id , string name , string description):base(id)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(
            string name,
            string description
            ) => new(MenuItemId.CreateUnique() , name, description);
    }
}
