using ErrorOr;
using MediatR;
using RestaurantDDD.Application.Authentication.Common;
using RestaurantDDD.Application.Common.Interfaces.Authentication;
using RestaurantDDD.Application.Common.Interfaces.Persistence;
using RestaurantDDD.Domain.Common.Errors;
using RestaurantDDD.Domain.Entities;

namespace RestaurantDDD.Application.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {

        // Inject JWT token to be used
        private readonly IJwtTokenGenerator _jwtTokGenerator;
        // Inject IUser Repo to be used
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokGenerator, IUserRepository userRepository)
        {
            _jwtTokGenerator = jwtTokGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // Check If user already exists
            var user = _userRepository.GetUserByEmail(request.Email);
            if (user != null)
            {
                return Errors.User.DuplicateEmail;
            }

            // Create a new User
            var newUser = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password
            };
            _userRepository.Add(newUser);
            // Create JWT
            string token = _jwtTokGenerator.GenerateToken(newUser);
            return new AuthenticationResult
            {
                User = newUser,
                Token = token,
            };
        }
        
    }
}
