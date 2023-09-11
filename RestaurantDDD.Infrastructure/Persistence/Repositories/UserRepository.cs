using RestaurantDDD.Application.Common.Interfaces.Persistence;
using RestaurantDDD.Domain.UserAggregate;

namespace RestaurantDDD.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly static List<User> _users = new List<User>();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}
