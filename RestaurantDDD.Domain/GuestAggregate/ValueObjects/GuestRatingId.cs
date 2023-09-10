using RestaurantDDD.Domain.Common.Models;

namespace RestaurantDDD.Domain.Guest.ValueObjects
{
    public sealed class GuestRatingId : ValueObject
    {
        public Guid Value { get; private set; }
        private GuestRatingId(Guid value)
        {
            Value = value;
        }

        public static GuestRatingId CreateUnique() => new GuestRatingId(Guid.NewGuid());
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}