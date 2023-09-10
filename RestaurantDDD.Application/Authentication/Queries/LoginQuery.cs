using ErrorOr;
using MediatR;
using RestaurantDDD.Application.Authentication.Common;

namespace RestaurantDDD.Application.Authentication.Queries
{
    public class LoginQuery : IRequest<ErrorOr<AuthenticationResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
