using RestaurantDDD.Domain.Common.Models;

namespace RestaurantDDD.Domain.Guest.ValueObjects
{
    public sealed class GuestId : ValueObject
    {
        public Guid Value { get; private set; }
        private GuestId(Guid value)
        {
            Value = value;
        }

        protected static GuestId CreateUnique() => new GuestId(Guid.NewGuid());
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}