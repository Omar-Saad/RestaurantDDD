using RestaurantDDD.Domain.Common.Models;

namespace RestaurantDDD.Domain.MenuReviewAggregate.ValueObjects
{
    public sealed class MenuReviewId : ValueObject
    {
        public Guid Value { get; private set; }
        private MenuReviewId(Guid value)
        {
            Value = value;
        }

        public static MenuReviewId CreateUnique() => new MenuReviewId(Guid.NewGuid());
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}