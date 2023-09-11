using RestaurantDDD.Domain.Common.Models;

namespace RestaurantDDD.Domain.DinnerAggregate.ValueObjects
{
    public sealed class DinnerId : ValueObject
    {
        public Guid Value { get; private set; }
        private DinnerId(Guid value)
        {
            Value = value;
        }

        public static DinnerId CreateUnique() => new DinnerId(Guid.NewGuid());
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}