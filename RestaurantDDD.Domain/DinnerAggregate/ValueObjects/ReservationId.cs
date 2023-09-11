using RestaurantDDD.Domain.Common.Models;

namespace RestaurantDDD.Domain.DinnerAggregate.ValueObjects
{
    public sealed class ReservationId : ValueObject
    {
        public Guid Value { get; private set; }
        private ReservationId(Guid value)
        {
            Value = value;
        }

        public static ReservationId CreateUnique() => new ReservationId(Guid.NewGuid());
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}