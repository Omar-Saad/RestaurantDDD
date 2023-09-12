using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.Common.ValueObjects;
using RestaurantDDD.Domain.DinnerAggregate.ValueObjects;
using RestaurantDDD.Domain.HostAggregate.ValueObjects;
using RestaurantDDD.Domain.MenuAggregate.Entities;
using RestaurantDDD.Domain.MenuAggregate.Events;
using RestaurantDDD.Domain.MenuAggregate.ValueObjects;
using RestaurantDDD.Domain.MenuReviewAggregate.ValueObjects;

namespace RestaurantDDD.Domain.MenuAggregate
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

        void AddDinner(DinnerAggregate.Dinner dinner)
        {
            // Todo Validation
            _dinnerIds.Add(dinner.Id);
        }
        void RemoveDinner(DinnerAggregate.Dinner dinner)
        {
            // TODO
            _dinnerIds.Remove(dinner.Id);
        }
        void UpdateSection(MenuSection section)
        {
            // TODO
        }
        private Menu() { }

        private Menu(MenuId id,
                    string name,
                    string description,
                    AverageRating averageRating,
                    HostId hostId,
                    List<MenuSection> sections,
                    DateTime createdDateTime,
                    DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Description = description;
            AverageRating = averageRating;
            HostId = hostId;
            _sections = sections;
            CreatedTime = createdDateTime;
            UpdatedTime = updatedDateTime;
        }






        public static Menu Create(string name,
                    string description,
                    HostId hostId,
                    List<MenuSection> sections
                    )
        {
            var menu = new Menu(
                          MenuId.CreateUnique(),
                          name,
                          description,
                          AverageRating.CreateNew(),
                          hostId,
                          sections,
                          DateTime.UtcNow,
                          DateTime.UtcNow);

            menu.AddDomainEvent(new MenuCreated(menu));
            return menu;

        }




    }
}
