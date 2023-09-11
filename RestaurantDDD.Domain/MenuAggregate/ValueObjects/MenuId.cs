using RestaurantDDD.Domain.Common.Models;

namespace RestaurantDDD.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; private set; }
        private MenuId(Guid value)
        {
            Value = value;
        }
        public static MenuId Create(Guid menuId) => new MenuId(menuId);
        public static MenuId CreateUnique() => new MenuId(Guid.NewGuid());
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}