using RestaurantDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDDD.Application.Authentication.Common
{
    public class AuthenticationResult
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
