using RestaurantDDD.Domain.Common.Models;

namespace RestaurantDDD.Domain.BillAggregate.ValueObjects
{
    public sealed class BillId : ValueObject
    {
        public Guid Value { get; private set; }
        private BillId(Guid value)
        {
            Value = value;
        }

        public static BillId CreateUnique() => new BillId(Guid.NewGuid());
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}