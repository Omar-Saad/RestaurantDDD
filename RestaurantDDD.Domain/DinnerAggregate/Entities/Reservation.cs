using RestaurantDDD.Domain.Bill.ValueObjects;
using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.Dinner.Enums;
using RestaurantDDD.Domain.Guest.ValueObjects;
using RestaurantDDD.Domain.Menu.ValueObjects;

namespace RestaurantDDD.Domain.Dinner.Entities
{
    public sealed class Reservation : Entity<ReservationId>
    {

        public int GuestCount { get; private set; }
        public ReservationStatus ReservationStatus { get; private set; }
        public GuestId GuestId { get; private set; }
        public BillId BillId { get; private set; }
        public DateTime ArrivalDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }


        private Reservation(
            ReservationId id,
            int guestCount,
          ReservationStatus reservationStatus,
          GuestId guestId,
          BillId billId,
          DateTime arrivalDateTime,
          DateTime updatedDateTime) : base(id)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            ArrivalDateTime = arrivalDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public Reservation Create(
            int guestCount,
          ReservationStatus reservationStatus,
          GuestId guestId,
          BillId billId
         ) => new(ReservationId.CreateUnique(),
                  guestCount,
                  reservationStatus,
                  guestId,
                  billId,
                  DateTime.UtcNow,
                  DateTime.UtcNow);

    }
}
