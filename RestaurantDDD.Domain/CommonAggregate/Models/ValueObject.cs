using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.Common.Models
{`
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null)) return false;

            return ReferenceEquals(left, right) || left.Equals(right);
        }



        public static bool operator ==(ValueObject left, ValueObject right) => EqualOperator(left, right);

        public static bool operator !=(ValueObject left, ValueObject right) => !EqualOperator(left, right);

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType()) return false;

            var valueObject = (ValueObject)obj;

            return GetEqualityComponents()
                    .SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                    .Select(x => x != null ? x.GetHashCode() : 0)
                    .Aggregate((x, y) => x ^ y);
        }

    }
}
