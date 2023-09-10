using ErrorOr;
using MediatR;
using RestaurantDDD.Application.Authentication.Common;
using RestaurantDDD.Application.Common.Interfaces.Authentication;
using RestaurantDDD.Application.Common.Interfaces.Persistence;
using RestaurantDDD.Domain.Common.Errors;

namespace RestaurantDDD.Application.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {

        // Inject JWT token to be used
        private readonly IJwtTokenGenerator _jwtTokGenerator;
        // Inject IUser Repo to be used
        private readonly IUserRepository _userRepository;


        public LoginQueryHandler(IJwtTokenGenerator jwtTokGenerator, IUserRepository userRepository)
        {
            _jwtTokGenerator = jwtTokGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            // Get User From IUserRepo (we don't care about the implementation)
            var user = _userRepository.GetUserByEmail(request.Email);
            if (user == null)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // Validate Password
            if (user.Password != request.Password)
            {

                return Errors.Authentication.InvalidCredentials;
            }
            // Get User token
            var token = _jwtTokGenerator.GenerateToken(user);
            return new AuthenticationResult
            {
                User = user,
                Token = token,

            };

        }
    }
}

