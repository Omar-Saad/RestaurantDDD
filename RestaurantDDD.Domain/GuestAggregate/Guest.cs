using RestaurantDDD.Domain.BillAggregate.ValueObjects;
using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.Common.ValueObjects;
using RestaurantDDD.Domain.DinnerAggregate.ValueObjects;
using RestaurantDDD.Domain.GuestAggregate.Entities;
using RestaurantDDD.Domain.GuestAggregate.ValueObjects;
using RestaurantDDD.Domain.MenuReviewAggregate.ValueObjects;
using RestaurantDDD.Domain.UserAggregate.ValueObjects;

namespace RestaurantDDD.Domain.GuestAggregate
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ProfileImage { get; private set; }
        public AverageRating AverageRating { get; private set; }
        public UserId UserId { get; private set; }
        private readonly List<DinnerId> _upcomingDinnerIds = new();
        private readonly List<DinnerId> _pastDinnerIds = new();
        private readonly List<BillId> _billIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<GuestRating> _ratingIds = new();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public IReadOnlyList<GuestRating> RatingIds => _ratingIds.AsReadOnly();

        private Guest() { }
        public Guest(
            GuestId id,
            string firstName,
                     string lastName,
                     string profileImage,
                     AverageRating averageRating,
                     UserId userId,
                     DateTime createdDateTime,
                     DateTime updatedDateTime) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public Guest Create(string firstName,
                     string lastName,
                     string profileImage,
                     AverageRating averageRating,
                     UserId userId) => new(GuestId.CreateUnique(),
                                           firstName,
                                           lastName,
                                           profileImage,
                                           averageRating,
                                           userId,
                                           DateTime.UtcNow,
                                           DateTime.UtcNow);
    }
}
