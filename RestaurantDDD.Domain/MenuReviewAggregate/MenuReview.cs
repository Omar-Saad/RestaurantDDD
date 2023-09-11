using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.Common.ValueObjects;
using RestaurantDDD.Domain.DinnerAggregate.ValueObjects;
using RestaurantDDD.Domain.GuestAggregate.ValueObjects;
using RestaurantDDD.Domain.HostAggregate.ValueObjects;
using RestaurantDDD.Domain.MenuAggregate.ValueObjects;
using RestaurantDDD.Domain.MenuReviewAggregate.ValueObjects;

namespace RestaurantDDD.Domain.MenuReviewAggregate
{
    public sealed class MenuReview : AggregateRoot<MenuReviewId>
    {
        public Rating Rating { get; private set; }
        public string Comment { get; private set; }
        public HostId HostId { get; private set; }
        public MenuId MenuId { get; private set; }
        public GuestId GuestId { get; private set; }
        public DinnerId DinnerId { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        private MenuReview() { }
        private MenuReview(
            MenuReviewId id,
            Rating rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Rating = rating;
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public MenuReview Create(Rating rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId)
            => new(MenuReviewId.CreateUnique(),
                   rating,
                   comment,
                   hostId,
                   menuId,
                   guestId,
                   dinnerId,
                   DateTime.UtcNow,
                   DateTime.UtcNow);
    }
}
