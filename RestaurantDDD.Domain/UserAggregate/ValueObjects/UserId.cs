using RestaurantDDD.Domain.Common.Models;

namespace RestaurantDDD.Domain.UserAggregate.ValueObjects
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
