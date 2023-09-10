using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.Common.ValueObjects;
using RestaurantDDD.Domain.Dinner;
using RestaurantDDD.Domain.Menu.Entities;
using RestaurantDDD.Domain.Menu.ValueObjects;

namespace RestaurantDDD.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating AverageRating { get; private set; }
        public HostId HostId { get; private set; }
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        public DateTime CreatedTime { get; private set; }
        public DateTime UpdatedTime { get; private set; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        void AddDinner(Dinner.Dinner dinner)
        {
            // Todo Validation
            _dinnerIds.Add(dinner.Id);
        }
        void RemoveDinner(Dinner.Dinner dinner)
        {
            // TODO
            _dinnerIds.Remove(dinner.Id);
        }
        void UpdateSection(MenuSection section)
        {
            // TODO
        }


        private Menu(MenuId id,
                    string name,
                    string description,
                    AverageRating averageRating,
                    HostId hostId,
                    DateTime createdDateTime,
                    DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Description = description;
            AverageRating = averageRating;
            HostId = hostId;
            CreatedTime = createdDateTime;
            UpdatedTime = updatedDateTime;
        }

     

        

     
        public Menu Create(string name,
                    string description,
                    AverageRating averageRating,
                    HostId hostId
                    ) => new(
                        MenuId.CreateUnique(),
                        name,
                        description,
                        averageRating,
                        hostId,
                        DateTime.UtcNow,
                        DateTime.UtcNow);




    }
}
