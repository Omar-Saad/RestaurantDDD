using RestaurantDDD.Domain.UserAggregate;

namespace RestaurantDDD.Application.Authentication.Common
{
    public class AuthenticationResult
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
