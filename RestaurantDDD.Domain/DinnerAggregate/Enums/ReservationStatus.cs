using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.DinnerAggregate.Enums
{
    public enum ReservationStatus
    {
        PendingGuestConfirmation, Reserved, Cancelled
    }
}
