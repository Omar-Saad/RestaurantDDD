using RestaurantDDD.Domain.CommonAggregate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.MenuAggregate.Events
{
   public record MenuCreated(Menu menu) : IDomianEvent;
}
