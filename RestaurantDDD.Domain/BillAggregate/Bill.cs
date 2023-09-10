using RestaurantDDD.Domain.Bill.ValueObjects;
using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.Common.ValueObjects;
using RestaurantDDD.Domain.Guest.ValueObjects;
using RestaurantDDD.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.Bill
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
