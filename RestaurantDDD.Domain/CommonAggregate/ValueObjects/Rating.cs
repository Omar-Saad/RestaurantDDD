using RestaurantDDD.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {

        public double Value { get; private set; }

        private Rating(double value)
        {
            Value = value;
        }
        public Rating CreateNew(double value = 0) => new Rating(value);


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
