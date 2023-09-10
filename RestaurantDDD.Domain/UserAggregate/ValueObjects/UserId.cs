using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.User.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; private set; }
        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId CreateUnique() => new UserId(Guid.NewGuid());
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
