using RestaurantDDD.Domain.BillAggregate.ValueObjects;
using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.Common.ValueObjects;
using RestaurantDDD.Domain.DinnerAggregate.ValueObjects;
using RestaurantDDD.Domain.GuestAggregate.ValueObjects;
using RestaurantDDD.Domain.HostAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.BillAggregate
{
    public sealed class Bill : AggregateRoot<BillId>
    {

        public DinnerId DinnerId { get; private set; }
        public GuestId GuestId { get; private set; }
        public HostId HostId { get; private set; }
        public Price Price { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        private Bill(
            BillId id,
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
            Price = price;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        private Bill() { }

        public Bill Create(DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price) => new(BillId.CreateUnique(),
                                dinnerId,
                                guestId,
                                hostId,
                                price,
                                DateTime.UtcNow,
                                DateTime.UtcNow);
    }


}
