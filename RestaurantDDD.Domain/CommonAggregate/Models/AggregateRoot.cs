using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Domain.Common.Models
{
    public class AggregateRoot<TId> : Entity<TId> where TId : notnull
    {
        protected AggregateRoot(TId id) : base(id)
        {
        }

        protected AggregateRoot()
        {
        }
    }
}
