using RestaurantDDD.Domain.Common.Models;

namespace RestaurantDDD.Domain.Menu.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value { get; private set; }
        private HostId(Guid value) {
        Value = value;
        }

        public static HostId CreateUnique() => new HostId(Guid.NewGuid());
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}