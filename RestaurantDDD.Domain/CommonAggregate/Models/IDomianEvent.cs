using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.CommonAggregate.Models
{
    public interface IDomianEvent : INotification
    {
    }
}
