using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.Common.ValueObjects;
using RestaurantDDD.Domain.Guest.ValueObjects;
using RestaurantDDD.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.Guest.Entities
{
    public sealed class GuestRating : Entity<GuestRatingId>
    {

        public HostId HostId { get; private set; }
        public DinnerId DinnerId { get; private set; }
        public Rating rating { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
    

    public GuestRating(
        GuestRatingId id,
        HostId hostId,
        DinnerId dinnerId,
        Rating rating,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        this.rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

        public GuestRating Create(HostId hostId,
        DinnerId dinnerId,
        Rating rating)
            => new(GuestRatingId.CreateUnique(),
                   hostId,
                   dinnerId,
                   rating,
                   DateTime.UtcNow,
                   DateTime.UtcNow);
}

}
