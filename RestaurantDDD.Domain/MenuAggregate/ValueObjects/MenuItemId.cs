using RestaurantDDD.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuItemId : ValueObject
    {
        public Guid Value { get; private set; }
        private MenuItemId(Guid value)
        {
            Value = value;
        }

        public static MenuItemId CreateUnique() => new MenuItemId(Guid.NewGuid());
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static MenuItemId Create(Guid value)
        => new MenuItemId(value);
    }
}
