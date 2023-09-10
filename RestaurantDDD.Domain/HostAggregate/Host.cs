using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.Common.ValueObjects;
using RestaurantDDD.Domain.Menu.ValueObjects;
using RestaurantDDD.Domain.User.ValueObjects;

namespace RestaurantDDD.Domain.Host
{
    public sealed class Host : AggregateRoot<HostId>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ProfileImage { get; private set; }
        public AverageRating AverageRating { get; private set; }

        public UserId UserId { get; private set; }

        private readonly List<MenuId> _menuIds = new List<MenuId>();
        private readonly List<DinnerId> _dinnerIds = new List<DinnerId>();



        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        private Host(
            HostId id,
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

        public static Host Create(
            string firstName,
           string lastName,
           string profileImage,
           AverageRating averageRating,
           UserId userId
            ) => new(HostId.CreateUnique(),
                     firstName,
                     lastName,
                     profileImage,
                     averageRating,
                     userId,
                     DateTime.UtcNow,
                     DateTime.UtcNow);


    }
}
