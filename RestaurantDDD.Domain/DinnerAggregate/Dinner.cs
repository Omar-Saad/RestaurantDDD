using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.Common.ValueObjects;
using RestaurantDDD.Domain.DinnerAggregate.Entities;
using RestaurantDDD.Domain.DinnerAggregate.Enums;
using RestaurantDDD.Domain.DinnerAggregate.ValueObjects;
using RestaurantDDD.Domain.HostAggregate.ValueObjects;
using RestaurantDDD.Domain.MenuAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.DinnerAggregate
{
    public sealed class Dinner : AggregateRoot<DinnerId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public DinnerStatus Status { get; private set; }
        public bool IsPublic { get; private set; }
        public int maxGuests { get; private set; }
        public Price Price { get; private set; }
        public HostId HostId { get; private set; }
        public MenuId MenuId { get; private set; }
        public string ImageUrl { get; private set; }
        public Location Location { get; private set; }
        private readonly List<Reservation> _reservations = new List<Reservation>();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }


        public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

        private Dinner() { }
        public Dinner(
            DinnerId id,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DinnerStatus status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = status;
            IsPublic = isPublic;
            this.maxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }


        public Dinner Create(
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location)
            => new(DinnerId.CreateUnique(),
                   name,
                   description,
                   startDateTime,
                   endDateTime,
                   DinnerStatus.Upcoming,
                   isPublic,
                   maxGuests,
                   price,
                   hostId,
                   menuId,
                   imageUrl,
                   location,
                   DateTime.UtcNow,
                   DateTime.UtcNow);
    }
}
