using RestaurantDDD.Domain.UserAggregate;

namespace RestaurantDDD.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);

        void Add(User user);
    }
}
