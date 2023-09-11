using RestaurantDDD.Domain.MenuAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Application.Common.Interfaces.Repositories
{
    public interface IMenuRepository
    {
        void Add(Menu menu);
    }
}
