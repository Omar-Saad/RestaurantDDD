using RestaurantDDD.Domain.Common.Models;

namespace RestaurantDDD.Domain.HostAggregate.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value { get; private set; }
        private HostId(Guid value)
        {
            Value = value;
        }

        public static HostId CreateUnique() => new HostId(Guid.NewGuid());

        public static HostId Create(Guid hostId) => new HostId(hostId);
        public static HostId Create(string hostId) => new HostId(Guid.Parse(hostId));
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}