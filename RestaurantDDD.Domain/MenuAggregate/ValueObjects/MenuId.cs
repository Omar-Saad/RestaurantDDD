
using RestaurantDDD.Domain.Common.Models;

namespace RestaurantDDD.Domain.Menu.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; private set; }
        private MenuId(Guid value) {
        Value = value;
        }

        public static MenuId CreateUnique() => new MenuId(Guid.NewGuid());
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}