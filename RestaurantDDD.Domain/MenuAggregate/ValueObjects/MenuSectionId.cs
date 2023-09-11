using RestaurantDDD.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuSectionId : ValueObject
    {
        public Guid Value { get; private set; }
        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUnique() => new MenuSectionId(Guid.NewGuid());
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static MenuSectionId Create(Guid value)
       => new MenuSectionId(value);
    }
}
